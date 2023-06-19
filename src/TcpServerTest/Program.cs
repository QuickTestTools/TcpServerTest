using TcpServerTest;
using Quick.Localize;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;
using System.Text;

var textManager = TextManager.DefaultInstance;
var title = textManager.GetText(Texts.Title);
var version = "1.0.0";
Console.Title = title;
Console.WriteLine(textManager.GetText(Texts.WelcomeText, title, version));
Console.WriteLine(textManager.GetText(Texts.RepoUrl, "https://github.com/QuickTestTools/TcpServerTest"));

string ipAddress = null;
int port = 0;

if (args.Length >= 2)
{
    ipAddress = args[0];
    port = int.Parse(args[1]);
}
else
{
    while (string.IsNullOrEmpty(ipAddress))
    {
        Console.Write(textManager.GetText(Texts.PleaseInputIpAddress));
        var line = Console.ReadLine();
        if (string.IsNullOrEmpty(line))
        {
            ipAddress = IPAddress.Any.ToString();
            break;
        }
        if (IPAddress.TryParse(line, out _))
            ipAddress = line;
    }
    while (port <= 0 || port > 65535)
    {
        Console.Write(textManager.GetText(Texts.PleaseInputPort));
        var line = Console.ReadLine();
        int.TryParse(line, out port);
    }
}

var dateFormat = textManager.GetText(Texts.DateFormat);
Console.Title = $"{ipAddress}:{port} - {title}";
TcpListener tcpListener = new TcpListener(IPAddress.Parse(ipAddress), port);
tcpListener.Start();


Console.WriteLine(textManager.GetText(Texts.ExitProgramTip));
while (true)
{
    var client = tcpListener.AcceptTcpClient();
    var clientEndpoint = client.Client.RemoteEndPoint.ToString();
    Console.WriteLine(textManager.GetText(Texts.NewClientConnected, clientEndpoint));
    _ = Task.Run(() =>
    {
        byte[] buffer = new byte[1024];
        using (var stream = client.GetStream())
        {
            try
            {
                while (true)
                {
                    var ret = stream.Read(buffer, 0, buffer.Length);
                    if (ret <= 0)
                        throw new IOException();
                    var text = Encoding.Default.GetString(buffer, 0, ret);
                    var hex = BitConverter.ToString(buffer, 0, ret);
                    Console.WriteLine(textManager.GetText(Texts.ClientDataRecved, clientEndpoint, text, hex));
                }
            }
            catch
            {
                Console.WriteLine(textManager.GetText(Texts.NewClientDisconnected, clientEndpoint));
                client.Dispose();
            }
        }
    });
}
