using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public double[,] ba = { { 1.0, 2.0 },{3.0,4.1} };
    }

    public struct DUTSetTransmitPowerVector_tag
    {
        public short lengthOfPowerVector;
        public short startingPacketLength;
        public short packetLengthIncrementPerIndex;
        //wchar_t powerIndexArray[96];           //C# char is 2byte,therefore, we need to use wchar_t in wrapper
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] powerIndexArray;

        //wchar_t numOfTransmitionPerPower[96];  //C# char is 2byte,therefore, we need to use wchar_t in wrapper
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] numOfTransmitionPerPower;

        //public short measuredVoltagePerPower[4][96];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * 2)]
        public double[,] measuredVoltagePerPower;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CLRIQMeasure cl = new CLRIQMeasure();
            //Console.Write(cl.add(100, 200));
            string videoName = "{\"ID\":2,\"Name\":\"鲁智深\",\"Age\":230,\"Sex\":\"男\"}";

            unsafe
            {
                IntPtr intPtrStr = (IntPtr)Marshal.StringToHGlobalAnsi(videoName);
                sbyte* sbyteStr = (sbyte*)intPtrStr;
                cl.showstr(sbyteStr);

                IntPtr pp=Marshal.AllocCoTaskMem(100);
                sbyte* p = (sbyte*)pp;
                cl.feedstr(p);
                string str = Marshal.PtrToStringAnsi(pp);
                
                //反序列化
                Student two = JsonConvert.DeserializeObject<Student>(str);

                Console.WriteLine(
                       string.Format("学生信息  ID:{0},姓名:{1},年龄:{2},性别:{3}",
                       two.ID, two.Name, two.Age, two.Sex));//显示结果
            }

            /*
            //序列化对象
            Student one = new Student()
            { ID = 1, Name = "武松", Age = 250, Sex = "男" };

            DUTSetTransmitPowerVector_tag tag = new DUTSetTransmitPowerVector_tag();
            tag.lengthOfPowerVector = 10;
            tag.startingPacketLength = 2;
            tag.packetLengthIncrementPerIndex = 1;
            tag.powerIndexArray =new int[2]{ 10,20};
            tag.numOfTransmitionPerPower = new int[2] { 1, 2 };
            tag.measuredVoltagePerPower = new double[2, 2] { { 2.3, 4.5 }, { 6.7, 8.9 } };

            //序列化
            string jsonData = JsonConvert.SerializeObject(tag);

            Console.WriteLine(jsonData);  //显示结果
            Console.ReadLine();

            //反序列化对象
            string str = "{\"ID\":2,\"Name\":\"鲁智深\",\"Age\":230,\"Sex\":\"男\"}";
            */
            
            
            Console.ReadLine();

        }
    }
}
