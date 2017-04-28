using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace POIGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_START_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
          
            wc.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

            Byte[] pageData = wc.DownloadData("http://www.poi86.com/poi/district/2545/1.html"); //从指定网站下载数据

            //string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

            string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句

            int startIndex = pageHtml.IndexOf("<table class=\"table table-bordered table-hover\">");
            int endIndex = pageHtml.IndexOf("</table>");

            string temp = pageHtml.Substring(startIndex, endIndex - startIndex + 1);  //截取新闻内容


            label3.Text = temp;
        }
    }
}
