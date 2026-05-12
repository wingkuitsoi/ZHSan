using Platforms;
using System;
using System.IO;
using Microsoft.Xna.Framework.Input;
using Serilog;
using System.Text;

namespace WorldOfTheThreeKingdoms;

public static class Program
{
    [STAThread]
    static void Main()
    {

        Console.OutputEncoding = Encoding.UTF8;
        /*bool flag;
        Mutex mutex = new Mutex(true, "WorldOfTheThreeKingdoms", out flag);
        if (!flag)
        {
            MessageBox.Show("游戏已经在运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        else
        {
            mutex.ReleaseMutex();
            new MainProcessManager().Processing();
        }*/

        // 配置Seriol日志
        var logTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext} - {Message:lj}{NewLine}{Exception}";

        Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Console(outputTemplate: logTemplate)
                            .WriteTo.File("logs/game.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3, outputTemplate: logTemplate)
                            .CreateLogger();

        string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        Directory.SetCurrentDirectory(exeDir);

        if (Platform.PlatFormType == PlatFormType.Win || Platform.PlatFormType == PlatFormType.Desktop)
        {
            using (MainGame game = new MainGame())
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    game.Run();
                }
                else
                {
                    try
                    {
                        game.Run();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);

                        MessageBox.Show("游戏错误", "中华三国志遇到严重错误，请提交游戏目录/logs/下的日志文件。", ["OK"]);
                    }
                }
            }
        }
        else if (Platform.PlatFormType == PlatFormType.UWP)
        {
            Platform.Current.OpenFactory();
        }

        Log.CloseAndFlush();
    }
}