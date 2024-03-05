namespace FreeSR.Tool.Proxy
{
    internal static class Program
    {
        private const string Title = "FreeSR Proxy";

        private static ProxyService s_proxyService;
        private static EventHandler s_processExitHandler = new EventHandler(OnProcessExit);

        private static void Main(string[] args)
        {
            Console.Title = Title;

            s_proxyService = new ProxyService("159.75.124.207", 8888);
            AppDomain.CurrentDomain.ProcessExit += s_processExitHandler;

            Thread.Sleep(-1);
        }

        private static void OnProcessExit(object sender, EventArgs args)
        {
            s_proxyService.Shutdown();
        }
    }
}
