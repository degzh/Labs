using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        

        private TcpListener tcpListener; 
        private TcpClient tcpClient;    
        private NetworkStream networkStream;
        private bool isRunning = true;
        private string nickname = "defaultname";
        private int port;                 
        public Form1()
        {
            InitializeComponent();
            GenerateRandomPort(); 
            txtChat.AppendText($"Ваш IP: {GetLocalIPAddress()} Порт: {port}{Environment.NewLine}");
        }

        private static readonly Dictionary<char, byte> koi8rToBytes = new Dictionary<char, byte>
        {
            ['А'] = 0xC1,
            ['Б'] = 0xC2,
            ['В'] = 0xC3,
            ['Г'] = 0xC4,
            ['Д'] = 0xC5,
            ['Е'] = 0xC6,
            ['Ё'] = 0xB3,
            ['Ж'] = 0xC7,
            ['З'] = 0xC8,
            ['И'] = 0xC9,
            ['Й'] = 0xCA,
            ['К'] = 0xCB,
            ['Л'] = 0xCC,
            ['М'] = 0xCD,
            ['Н'] = 0xCE,
            ['О'] = 0xCF,
            ['П'] = 0xD0,
            ['Р'] = 0xD1,
            ['С'] = 0xD2,
            ['Т'] = 0xD3,
            ['У'] = 0xD4,
            ['Ф'] = 0xD5,
            ['Х'] = 0xD6,
            ['Ц'] = 0xD7,
            ['Ч'] = 0xD8,
            ['Ш'] = 0xD9,
            ['Щ'] = 0xDA,
            ['Ъ'] = 0xDB,
            ['Ы'] = 0xDC,
            ['Ь'] = 0xDD,
            ['Э'] = 0xDE,
            ['Ю'] = 0xDF,
            ['Я'] = 0xE0,
            ['а'] = 0xE1,
            ['б'] = 0xE2,
            ['в'] = 0xE3,
            ['г'] = 0xE4,
            ['д'] = 0xE5,
            ['е'] = 0xE6,
            ['ё'] = 0xA3,
            ['ж'] = 0xE7,
            ['з'] = 0xE8,
            ['и'] = 0xE9,
            ['й'] = 0xEA,
            ['к'] = 0xEB,
            ['л'] = 0xEC,
            ['м'] = 0xED,
            ['н'] = 0xEE,
            ['о'] = 0xEF,
            ['п'] = 0xF0,
            ['р'] = 0xF1,
            ['с'] = 0xF2,
            ['т'] = 0xF3,
            ['у'] = 0xF4,
            ['ф'] = 0xF5,
            ['х'] = 0xF6,
            ['ц'] = 0xF7,
            ['ч'] = 0xF8,
            ['ш'] = 0xF9,
            ['щ'] = 0xFA,
            ['ъ'] = 0xFB,
            ['ы'] = 0xFC,
            ['ь'] = 0xFD,
            ['э'] = 0xFE,
            ['ю'] = 0xFF,
            ['я'] = 0xC0,
            [' '] = 0x20,
            ['.'] = 0x2E,
            [','] = 0x2C,
            ['!'] = 0x21,
            ['?'] = 0x3F,
            ['-'] = 0x2D,
            ['0'] = 0x30,
            ['1'] = 0x31,
            ['2'] = 0x32,
            ['3'] = 0x33,
            ['4'] = 0x34,
            ['5'] = 0x35,
            ['6'] = 0x36,
            ['7'] = 0x37,
            ['8'] = 0x38,
            ['9'] = 0x39
        };

        private static readonly Dictionary<byte, char> bytesToKoi8r = koi8rToBytes.ToDictionary(kv => kv.Value, kv => kv.Key);

        private void GenerateRandomPort()
        {
            var random = new Random();
            port = random.Next(1024, 65535); 
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            return "127.0.0.1";
        }

        private void btnSetNickname_Click(object sender, EventArgs e)
        {
            
        }

        private async void btnStartServer_Click(object sender, EventArgs e)
        {
            
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                var stream = client.GetStream();
                var buffer = new byte[1024];

                while (isRunning)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        byte[] receivedBytes = new byte[bytesRead];
                        Array.Copy(buffer, receivedBytes, bytesRead);

                        string decodedMessage = new string(receivedBytes.Select(b => bytesToKoi8r.ContainsKey(b) ? bytesToKoi8r[b] : '?').ToArray());

                        string byteCodes = string.Join(" ", receivedBytes.Select(b => $"0x{b:X2}"));

                        string binaryCodes = string.Join(" ", receivedBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

                        txtChat.Invoke(new Action(() =>
                        {
                            txtChat.AppendText($"Получено: {decodedMessage}{Environment.NewLine}");
                            txtChat.AppendText($"Коды KOI8-R: {byteCodes}{Environment.NewLine}");
                            txtChat.AppendText($"Бинарный код: {binaryCodes}{Environment.NewLine}");
                        }));
                    }
                }
            }
            catch (Exception ex)
            {
                txtChat.Invoke(new Action(() =>
                {
                    txtChat.AppendText($"Ошибка обработки клиента: {ex.Message}{Environment.NewLine}");
                }));
            }
        }
        private async void btnConnect_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
        }

        private async void StartReceiving()
        {
            await Task.Run(() =>
            {
                byte[] buffer = new byte[1024];

                while (isRunning)
                {
                    try
                    {
                        int bytesRead = networkStream.Read(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            byte[] receivedBytes = new byte[bytesRead];
                            Array.Copy(buffer, receivedBytes, bytesRead);

                            string decodedMessage = new string(receivedBytes.Select(b => bytesToKoi8r.ContainsKey(b) ? bytesToKoi8r[b] : '?').ToArray());

                            string byteCodes = string.Join(" ", receivedBytes.Select(b => $"0x{b:X2}"));

                            string binaryCodes = string.Join(" ", receivedBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

                            txtChat.Invoke(new Action(() =>
                            {
                                txtChat.AppendText($"Получено: {decodedMessage}{Environment.NewLine}");
                                txtChat.AppendText($"Коды KOI8-R: {byteCodes}{Environment.NewLine}");
                                txtChat.AppendText($"Бинарный код: {binaryCodes}{Environment.NewLine}");
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!isRunning) break;
                        txtChat.Invoke(new Action(() =>
                        {
                            txtChat.AppendText($"Ошибка приёма: {ex.Message}{Environment.NewLine}");
                        }));
                    }
                }
            });
        }

        private string ConvertToBinary(byte[] data)
        {
            StringBuilder binaryBuilder = new StringBuilder();
            foreach (byte b in data)
            {
                binaryBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
            }
            return binaryBuilder.ToString().Trim();
        }

        private void TcpChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
            networkStream?.Close();
            tcpClient?.Close();
            tcpListener?.Stop();
        }

        private async void btnStartServer_Click_1(object sender, EventArgs e)
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                txtChat.AppendText($"Сервер запущен на {GetLocalIPAddress()}:{port}{Environment.NewLine}");

                await Task.Run(() =>
                {
                    while (isRunning)
                    {
                        try
                        {
                            var client = tcpListener.AcceptTcpClient();
                            Task.Run(() => HandleClient(client));
                        }
                        catch (Exception ex)
                        {
                            if (!isRunning) break;
                            txtChat.Invoke(new Action(() =>
                            {
                                txtChat.AppendText($"Ошибка сервера: {ex.Message}{Environment.NewLine}");
                            }));
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Ошибка запуска сервера: {ex.Message}{Environment.NewLine}");
            }
        }

        private async void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                string serverIp = txtServerIp.Text;
                int serverPort = int.Parse(txtServerPort.Text);

                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(serverIp, serverPort);
                networkStream = tcpClient.GetStream();

                txtChat.AppendText($"Подключено к серверу {serverIp}:{serverPort}.{Environment.NewLine}");
                StartReceiving();
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Ошибка подключения: {ex.Message}{Environment.NewLine}");
            }
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            if (networkStream == null || !tcpClient.Connected)
            {
                MessageBox.Show("Нет подключения к серверу.");
                return;
            }

            string message = txtMessage.Text;
            if (string.IsNullOrWhiteSpace(message)) return;

            try
            {
                string fullMessage = $"{nickname}: {message}";

                byte[] messageBytes = fullMessage.Select(c => koi8rToBytes.ContainsKey(c) ? koi8rToBytes[c] : (byte)0x3F).ToArray();

                string byteCodes = string.Join(" ", messageBytes.Select(b => $"0x{b:X2}"));

                string binaryCodes = string.Join(" ", messageBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));

                networkStream.Write(messageBytes, 0, messageBytes.Length);

                txtChat.AppendText($"Вы: {fullMessage}{Environment.NewLine}");
                txtChat.AppendText($"Коды KOI8-R: {byteCodes}{Environment.NewLine}");
                txtChat.AppendText($"Бинарный код: {binaryCodes}{Environment.NewLine}");

                txtMessage.Clear();
            }
            catch (Exception ex)
            {
                txtChat.AppendText($"Ошибка отправки: {ex.Message}{Environment.NewLine}");
            }
        }

        private void btnSetNickname_Click_1(object sender, EventArgs e)
        {
            nickname = txtNickname.Text;
            if (string.IsNullOrWhiteSpace(nickname)) nickname = "defaultname";
            txtChat.AppendText($"Ваш никнейм установлен как: {nickname}{Environment.NewLine}");
        }
    }
}


