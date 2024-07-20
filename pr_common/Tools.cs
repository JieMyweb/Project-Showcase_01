using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_common
{
    public class Tools
    {
        public static string CreateValidateString()
        {
            //供驗證碼展示的數據
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Microsecond);
            string validateString = "";
            int length = 4;
            for(int i = 0;i < length; i++)
            {
                validateString += chars[r.Next(chars.Length)];
            }
            return validateString;
        }

        public static Byte[] CreateValidateCodeBuffer(string validateCode)
        {
            //1.創建畫布
            using Bitmap bitmap = new(200, 60);

            //2.創建畫筆,告訴畫筆在哪個畫布畫畫
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);//用白色覆蓋畫布，並清除畫布上所有內容

            //設置字體參數
            Font font = new("微軟雅黑體", 12, FontStyle.Bold | FontStyle.Italic);
            var size = graphics.MeasureString(validateCode, font);
            using Bitmap bitmapText = new(Convert.ToInt32(Math.Ceiling(size.Width)), Convert.ToInt32(Math.Ceiling(size.Height)));

            // 1. 創建圖形對象
            Graphics graphicsText = Graphics.FromImage(bitmapText);

            // 2. 將圖片縮放到更大畫布上
            RectangleF rf = new(0, 0, bitmap.Width, bitmap.Height);

            // 3. 設置用於漸變填充的區域
            LinearGradientBrush brush = new(rf, Color.Red, Color.DarkBlue, 1.2f, true);

            // 4. 將字符串繪製到場景中
            graphicsText.DrawString(validateCode, font, brush, 0, 0);
            graphics.DrawImage(bitmapText, 10, 10, 190, 50);    

            // 5. 將圖片保存到流中
            // 5.1 創建一用於保存圖片的緩衝器
            MemoryStream memoryStream = new();
            // 5.2 把圖片保存到緩衝區
            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            // 6. 這個時候暫存已經在緩衝區中了，bitmap對象自然就沒有用了，卸磨殺驢之
            bitmap.Dispose();

            return memoryStream.ToArray();
        }
    }
}
