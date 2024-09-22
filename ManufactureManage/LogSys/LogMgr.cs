using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using log4net;

namespace ManufactureManage.LogSys
{
    public class LogMgr : IDisposable
    {
        public Action<string> LogEvent;

        private readonly ILog _logger = LogManager.GetLogger(nameof(LogMgr));
        private readonly object _syncRoot = new object();
        private bool _isInited = false;
        private UdpClient _udpClient;
        private IPEndPoint _endPoint;

        public LogMgr()
        {

        }

        ~LogMgr()
        {
            Close();
        }

        public void Close()
        {
            _udpClient?.Close();
        }
        public void Dispose()
        {
            Close();
        }

        public void Init(int port = 60050)
        {
            lock (_syncRoot)
            {
                if (_isInited)
                    return;

                _endPoint = new IPEndPoint(IPAddress.Any, port);
                _udpClient = new UdpClient(_endPoint);
                _udpClient.BeginReceive(EndReceive, Tuple.Create(_udpClient, _endPoint));
                _isInited = true;
            }
        }

        private void EndReceive(IAsyncResult ar)
        {
            try
            {
                if (!(ar.AsyncState is Tuple<UdpClient, IPEndPoint> entity))
                    return;

                var udpClient = entity.Item1;
                var udpPoint = entity.Item2;

                var bytes = udpClient.EndReceive(ar, ref udpPoint);
                var s = bytes.ToUTF8String();

                LogEvent?.Invoke(s);

                udpClient.BeginReceive(EndReceive, Tuple.Create(udpClient, udpPoint));
            }
            catch (IOException ioe)
            {
                _logger.DebugFormat("IOException encountered {0}", ioe.Message);
                //如果是链接关闭则不再进行异步读取数据
                if (ioe.InnerException is SocketException socketException && socketException.ErrorCode == 10054)
                    return;
                //throw;//不抛出异常
                _logger.Error(ioe.Message);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }


    }
}
