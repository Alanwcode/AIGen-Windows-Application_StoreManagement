using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace projectPrototypeTwo
{
    class sendMail
    {
        String mailAddress = "";

        public void SendEmail_LoadData()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True";
            SqlCommand sqlCommand = new SqlCommand("select email from customer", sqlConnection); 
            

            SqlDataReader dr = sqlCommand.ExecuteReader();

            while (dr.Read())
            {
                byte[] array = new byte[4];
                mailAddress = dr.GetValue(array[0]).ToString();
            }
            sqlConnection.Close();
            sqlCommand.Dispose();

        }


        // --------------------------------------

        public string getHtml()
        {
            try
            {
                string messageBody = "<font>The following are the records: </font><br><br>";
                //if (grid.RowCount == 0) return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart +  htmlTdEnd;
                messageBody += htmlTdStart + htmlTdEnd;
                messageBody += htmlTdStart + htmlTdEnd;
                messageBody += htmlTdStart + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;
               
                messageBody = messageBody + htmlTableEnd;
                return messageBody; // return HTML Table as string from this function  
            }
            catch (Exception)
            {
                return null;
            }
        }

        //---------------------------------------------------------------------------------------

        public void Email(string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ramesharukshan3@gmail.com");
                message.To.Add(new MailAddress("ramesharukshan3@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ramesharukshan3@gmail.com", "Local@area51");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }
    }
}
