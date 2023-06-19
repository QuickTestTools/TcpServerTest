using Quick.Localize;

namespace TcpServerTest
{
    [TextResource]
    public enum Texts
    {
        [Text("en-US", "MM/dd/yyyy HH:mm:ss")]
        [Text("zh-CN", "yyyy-MM-dd HH:mm:ss")]
        DateFormat,
        [Text("en-US", "TcpServer Test Tool")]
        [Text("zh-CN", "TcpServer测试工具")]
        Title,
        [Text("en-US", "Welcome to use {0}_v{1}")]
        [Text("zh-CN", "欢迎使用{0}_v{1}")]
        WelcomeText,
        [Text("en-US", "Repo Url:{0}")]
        [Text("zh-CN", "仓库地址:{0}")]
        RepoUrl,
        [Text("en-US", "Please input IPAddress(Default:0.0.0.0):")]
        [Text("zh-CN", "请输入IP地址(默认:0.0.0.0)：")]
        PleaseInputIpAddress,
        [Text("en-US", "Please input listen port:")]
        [Text("zh-CN", "请输入监听端口：")]
        PleaseInputPort,
        [Text("en-US", "[Press Ctrl+C to exit]")]
        [Text("zh-CN", "[按Ctrl+C终止程序]")]
        ExitProgramTip,
        [Text("en-US", "[{0}]Connected")]
        [Text("zh-CN", "[{0}]已连接")]
        NewClientConnected,
        [Text("en-US", "[{0}]Disconnected")]
        [Text("zh-CN", "[{0}]已断开")]
        NewClientDisconnected,
        [Text("en-US", "[{0}][RX]\r\nText: {1}\r\nHex:{2}")]
        [Text("zh-CN", "[{0}][收到数据]\r\n文本: {1}\r\n16进制: {2}")]
        ClientDataRecved
    }
}
