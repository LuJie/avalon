using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ConnectInfoEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            write();
            MessageBox.Show("Finished. Make sure it wrote OK. There is no error checking.");
        }

        private void write()
        {
            int size;
            byte[] bSize;
            if (File.Exists(PathBox.Text))
            {
                File.Delete(PathBox.Text);
            }
            using (Stream output = new FileStream(PathBox.Text, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] header = new byte[8];
                output.Write(header, 0, header.Length);

                string errReport = tbErrorReport.Text.ToString(); 
                byte[] uniReport = Encoding.Unicode.GetBytes(errReport);

                size = errReport.Length + 1;
                bSize = BitConverter.GetBytes(size);

                output.Write(bSize, 0, bSize.Length);
                output.Write(uniReport, 0, uniReport.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                string listCon = tbListConn.Text.ToString();
                byte[] uniCon = Encoding.Unicode.GetBytes(listCon);

                size = listCon.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                byte[] blank7 = new byte[12];
                string server1 = tbsvrname1.Text.ToString();
                string server2 = tbsvrname2.Text.ToString();
                string server3 = tbsvrname3.Text.ToString();
                byte[] bServ1 = Encoding.Unicode.GetBytes(server1);
                byte[] bServ2 = Encoding.Unicode.GetBytes(server2);
                byte[] bServ3 = Encoding.Unicode.GetBytes(server3);
                string serverx = tbsvrname4.Text.ToString();
                byte[] bServx = Encoding.Unicode.GetBytes(serverx);
                size = server1.Length + 1;
                bSize = BitConverter.GetBytes(size);
                string serverIP = tbSrvIP.Text.ToString();
                byte[] bServIP = Encoding.Unicode.GetBytes(serverIP);
                string shopADD = tbItemShop.Text.ToString();
                byte[] bShopADD = Encoding.Unicode.GetBytes(shopADD);
                string ch1Sv = tbChsrv1.Text.ToString();
                byte[] bch1Sv = Encoding.Unicode.GetBytes(ch1Sv);
                string ch2Sv = tbChsrv2.Text.ToString();
                byte[] bch2Sv = Encoding.Unicode.GetBytes(ch2Sv);
                string uGuildMark = tbGuildmarkupload.Text.ToString();
                byte[] buGuildMark = Encoding.Unicode.GetBytes(uGuildMark);
                string sGuildMark = tbGuildmarkshow.Text.ToString();
                byte[] bsGuildMark = Encoding.Unicode.GetBytes(sGuildMark);
                string ShopItem1 = tbItem1.Text.ToString();
                byte[] bShopItem1 = Encoding.Unicode.GetBytes(ShopItem1);
                string ShopItem2 = tbItem2.Text.ToString();
                byte[] bShopItem2 = Encoding.Unicode.GetBytes(ShopItem2);
                string ShopItem3 = tbItem3.Text.ToString();
                byte[] bShopItem3 = Encoding.Unicode.GetBytes(ShopItem3);
                string ShopItem4 = tbItem4.Text.ToString();
                byte[] bShopItem4 = Encoding.Unicode.GetBytes(ShopItem4);
                string ShopItem5 = tbItem5.Text.ToString();
                byte[] bShopItem5 = Encoding.Unicode.GetBytes(ShopItem5);
                string ShopItem6 = tbItem6.Text.ToString();
                byte[] bShopItem6 = Encoding.Unicode.GetBytes(ShopItem6);
                string ShopItem7 = tbItem7.Text.ToString();
                byte[] bShopItem7 = Encoding.Unicode.GetBytes(ShopItem7);

                string ShopPreview = shopPreview.Text.ToString();
                byte[] bShopPreview = Encoding.Unicode.GetBytes(ShopPreview);

                string HotList = hotList.Text.ToString();
                byte[] bHotList = Encoding.Unicode.GetBytes(HotList);

                string CatList = cList.Text.ToString();
                byte[] bCatList = Encoding.Unicode.GetBytes(CatList);

                string GiftList = gList.Text.ToString();
                byte[] bGiftList = Encoding.Unicode.GetBytes(GiftList);

                string PrevInfo = prevInfo.Text.ToString();
                byte[] bPrevInfo = Encoding.Unicode.GetBytes(PrevInfo);

                string PVPRank = tbPVPRank.Text.ToString();

                byte[] bPVPRank = Encoding.Unicode.GetBytes(PVPRank);
                output.Write(uniCon, 0, uniCon.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(1);
                output.Write(blank7, 0, blank7.Length);

                size = server1.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);

                output.Write(bServ1, 0, bServ1.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                size = server2.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);

                output.Write(bServ2, 0, bServ2.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                size = server3.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bServ3, 0, bServ3.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(14);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.Write(bServx, 0, bServx.Length - 1);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                size = serverIP.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bServIP, 0, bServIP.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                output.WriteByte(0xbe);//end srv list
                output.WriteByte(0x3c);//end srv list
                size = shopADD.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopADD, 0, bShopADD.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                size = PVPRank.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bPVPRank, 0, bPVPRank.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(1);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                size = ch1Sv.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bch1Sv, 0, bch1Sv.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0xc4);
                output.WriteByte(0x3c);
                output.WriteByte(0);
                output.WriteByte(0);
                size = ch2Sv.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bch2Sv, 0, bch2Sv.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0xc4);
                output.WriteByte(0x3c);
                output.WriteByte(0);
                output.WriteByte(0);
                size = uGuildMark.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(buGuildMark, 0, buGuildMark.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                size = sGuildMark.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bsGuildMark, 0, bsGuildMark.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(7);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0x78);
                output.WriteByte(0x8a);
                output.WriteByte(0x05);
                output.WriteByte(0);

                size = ShopItem1.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem1, 0, bShopItem1.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0x3F);
                output.WriteByte(0xB5);
                output.WriteByte(0x14);
                output.WriteByte(0);
                size = ShopItem2.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem2, 0, bShopItem2.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0x8C);
                output.WriteByte(0x4E);
                output.WriteByte(0x6D);
                output.WriteByte(0);

                size = ShopItem3.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem3, 0, bShopItem3.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0xF2);
                output.WriteByte(0xFB);
                output.WriteByte(0x8F);
                output.WriteByte(0);

                size = ShopItem4.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem4, 0, bShopItem4.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0xBA);
                output.WriteByte(0x9D);
                output.WriteByte(0xE9);
                output.WriteByte(0);

                size = ShopItem5.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem5, 0, bShopItem5.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0x93);
                output.WriteByte(0xA5);
                output.WriteByte(0xEC);
                output.WriteByte(0);

                size = ShopItem6.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem6, 0, bShopItem6.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0x14);
                output.WriteByte(0x53);
                output.WriteByte(0xF6);
                output.WriteByte(1);

                size = ShopItem7.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopItem7, 0, bShopItem7.Length);
                output.WriteByte(0);
                output.WriteByte(0);
                output.WriteByte(0);

                size = ShopPreview.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bShopPreview, 0, bShopPreview.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                size = HotList.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bHotList, 0, bHotList.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                size = CatList.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bCatList, 0, bCatList.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                size = GiftList.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bGiftList, 0, bGiftList.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                size = PrevInfo.Length + 1;
                bSize = BitConverter.GetBytes(size);
                output.Write(bSize, 0, bSize.Length);
                output.Write(bPrevInfo, 0, bPrevInfo.Length);
                output.WriteByte(0);
                output.WriteByte(0);

                //<bh:01><bh:00><bh:00><bh:00><bh:00><bh:00><bh:01><bh:00><bh:00><bh:00><bh:00><bh:00><bh:01><bh:00><bh:00><bh:00><bh:00><bh:00><bh:01><bh:00><bh:00><bh:00><bh:00><bh:00><bh:00>
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey OurKey = Registry.CurrentUser;
            string path;
            try
            {
                OurKey = OurKey.OpenSubKey(@"Software\HanGame.Com\ENGLISH\U_LUNIA", false);
                PathBox.Text = OurKey.GetValue("Install_Dir").ToString() + "\\ConnectInfo.b";
                OurKey.Close();
            }
            catch (System.NullReferenceException error)
            {
                MessageBox.Show("No reg key found for install path. Use browse.", error.Message);
            }

            //HKEY_CURRENT_USER\Software\HanGame.Com\ENGLISH\U_LUNIA
            //    "Install_Dir"="x:\\LuniaClient"

        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog browsefile = new OpenFileDialog();
            browsefile.Filter = "ConnectInfo.b|ConnectInfo.b|All Files (*)|*";
            browsefile.FilterIndex = 1;
            browsefile.RestoreDirectory = true;
            if (browsefile.ShowDialog() == DialogResult.OK)
            {
                PathBox.Text = browsefile.FileName;   
            }
        }
    }
}
