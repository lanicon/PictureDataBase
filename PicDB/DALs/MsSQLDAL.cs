using System;
using System.Collections.Generic;
using PicDB.Models;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace PicDB.DALs
{
    public class MsSQLDAL : IDAL
    {
        SqlConnection connection;
        String connectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                AttachDbFilename=C:\Users\fruti\OneDrive\Desktop\PicDB\PicDBFile.mdf;
                Integrated Security=True;
                Connect Timeout=30;";

        public void delete(PictureModel p)
        {
        }

        public PictureModel getPicture(int ID)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pictures WHERE Id = " + ID, connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                return new PictureModel((int)table.Rows[0][0], (string)table.Rows[0][1]);
            }
        }


        public List<PictureModel> getPictures()
        {
            List<PictureModel> pics = new List<PictureModel>();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pictures", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    pics.Add(new PictureModel((int)row[0], (string)row[1]));
                }

                return pics;
            }
        }


        public EXIFModel getExif(int ID)
        {
            EXIFModel exif = new EXIFModel();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pictures WHERE Id = " + ID, connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                exif.ExifCameraModel = (string)table.Rows[0][2];
                exif.FNumber = (double)table.Rows[0][3];
                exif.ExposureTime = (int)table.Rows[0][4];
                exif.DateTime = (DateTime)table.Rows[0][5];

                return exif;
            }
        }

        public IPTCModel GetIPTC(int ID)
        {
            IPTCModel iptc = new IPTCModel();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pictures WHERE Id = " + ID, connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                iptc.City = (string)table.Rows[0][6];
                iptc.Caption = (string)table.Rows[0][7];
                iptc.Headline = (string)table.Rows[0][8];

                return iptc;
            }
        }

        public void SaveIPTC(int id, IPTCModel iptc)
        {
            connection = new SqlConnection(connectionString);


            string sql = "update Pictures set Iptc_City = '" + iptc.City + "', " +
                "Iptc_Caption = '" + iptc.Caption + "', " +
                "Iptc_Headline = '" + iptc.Headline + "' " +
                "where Id = '" + id + "'";

            using (connection)
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                connection.Open();

                adapter.UpdateCommand = new SqlCommand(sql, connection);
                adapter.UpdateCommand.ExecuteNonQuery();
            }
        }


        public void initialize()
        {
            throw new NotImplementedException();
        }

        public void save(PictureModel p)
        {
            throw new NotImplementedException();
        }

        public List<PhotographerModel> getPhotographerList()
        {
            List<PhotographerModel> photographers = new List<PhotographerModel>();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Photographers", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    PhotographerModel temp = new PhotographerModel();

                    temp.ID = (int)row["Id"];
                    temp.FirstName = (string)row["FirstName"];
                    temp.LastName = (string)row["LastName"];
                    temp.Birthday = (DateTime)row["Birthday"];
                    temp.Notes = (string)row["Notes"];

                    photographers.Add(temp);
                }

                return photographers;
            }
        }


        public PhotographerModel getPhotographer(int ID)
        {
            PhotographerModel phm = new PhotographerModel();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Photographers WHERE Id = " + ID, connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                phm.ID = (int)table.Rows[0]["Id"];
                phm.FirstName = (string)table.Rows[0]["FirstName"];
                phm.LastName = (string)table.Rows[0]["LastName"];
                phm.Birthday = (DateTime)table.Rows[0]["Birthday"];
                phm.Notes = (string)table.Rows[0]["Notes"];

                return phm;
            }
        }

        public PhotographerModel getPhotographerOfPicture(int pictureId)
        {
            PhotographerModel phm = new PhotographerModel();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Photographers WHERE Id = (SELECT Photographer_Id from Pictures WHERE Id = " + pictureId + ")", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);

                phm.ID = (int)table.Rows[0]["Id"];
                phm.FirstName = (string)table.Rows[0]["FirstName"];
                phm.LastName = (string)table.Rows[0]["LastName"];
                phm.Birthday = (DateTime)table.Rows[0]["Birthday"];
                phm.Notes = (string)table.Rows[0]["Notes"];

                return phm;
            }
        }

        public void SavePhotographer(int id, PhotographerModel photographer)
        {
            connection = new SqlConnection(connectionString);

            string sql = "update Photographers set FirstName = '" + photographer.FirstName + "', " +
                "LastName = '" + photographer.LastName + "', " +
                "Birthday = '" + photographer.Birthday + "', " +
                "Notes = '" + photographer.Notes + "' " +
                "where Id = '" + id + "'";

            using (connection)
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                connection.Open();

                adapter.UpdateCommand = new SqlCommand(sql, connection);
                adapter.UpdateCommand.ExecuteNonQuery();
            }
        }

        public void SaveNewPhotographer(PhotographerModel photographer)
        {
            connection = new SqlConnection(connectionString);

            string sql = "INSERT INTO Photographers(\"FirstName\", \"LastName\", \"Birthday\", \"Notes\") VALUES ('" +
                photographer.FirstName + "', '" +
                photographer.LastName + "', '" +
                photographer.Birthday.Value.Year + "-" + photographer.Birthday.Value.Month + "-" + photographer.Birthday.Value.Day + "', '" +
                photographer.Notes + "');";

            using (connection)
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
                connection.Open();

                adapter.InsertCommand = new SqlCommand(sql, connection);
                adapter.InsertCommand.ExecuteNonQuery();
            }
        }






        public void makeTagReport()
        {
            DataTable table = new DataTable();

            string sql =
                "SELECT Tags.Tag, COUNT(Pictures_Tags.Tag_ID) AS amount " +
                "FROM Pictures_Tags " +
                "LEFT JOIN Tags ON Pictures_Tags.Tag_ID = Tags.Id " +
                "GROUP BY Tags.Tag " +
                "ORDER BY amount DESC;";

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
            {
                adapter.Fill(table);
            }

            //PdfDocument pdf = new PdfDocument();
            //pdf.Info.Title = "Tag Report";
            //PdfPage page = pdf.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            //XFont headlineFont = new XFont("Arial", 20, XFontStyle.BoldItalic);
            //gfx.DrawString("Tag Report", headlineFont, XBrushes.Black, new XRect(0, 0, page.Width, 100), XStringFormats.Center);


            //XFont textFont = new XFont("Arial", 10, XFontStyle.Regular);
            //XFont boldFont = new XFont("Arial", 10, XFontStyle.Bold);

            //int count = 0;
            //foreach (DataRow dr in table.Rows)
            //{
            //    gfx.DrawString((string)dr["Tag"] + ":", boldFont, XBrushes.Black, new XRect(50, 150 + count*20, 100, 0), XStringFormats.BaseLineLeft);
            //    gfx.DrawString("" + (int)dr["amount"] + " Occurences", textFont, XBrushes.Black, new XRect(120, 150 + count*20, 100, 0), XStringFormats.BaseLineLeft);

            //    count++;
            //}

            //    string filename = "Reports\\Tag Report.pdf";
            //    pdf.Save(filename);
            //    Process.Start(filename);
            //
        }




        public void makePictureReport(int pictureId)
        {
            DataTable table = new DataTable();
            DataTable table2 = new DataTable();

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Pictures WHERE Id = " + pictureId, connection))
            {
                adapter.Fill(table);
            }

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Photographers WHERE Id = (SELECT Photographer_Id from Pictures WHERE Id = " + pictureId + ")", connection))
            {
                adapter.Fill(table2);
            }



            //PdfDocument pdf = new PdfDocument();
            //pdf.Info.Title = "Report for Picture " + (string)table.Rows[0]["Iptc_Headline"];
            //PdfPage page = pdf.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);

            //XImage image = XImage.FromFile((string)table.Rows[0]["Path"]);

            //if (image.PixelWidth >= image.PixelHeight)
            //{
            //    gfx.DrawImage(image, 50, 100, 500, 500 * image.PixelHeight / image.PixelWidth);

            //}
            //else
            //{
            //    gfx.DrawImage(image, 150, 100, 400 * image.PixelWidth / image.PixelHeight, 400);
            //}

            //XFont headlineFont = new XFont("Arial", 20, XFontStyle.BoldItalic);
            //gfx.DrawString((string)table.Rows[0]["Iptc_Headline"], headlineFont, XBrushes.Black, new XRect(0, 0, page.Width, 100), XStringFormats.Center);

            //XFont textFont = new XFont("Arial", 10, XFontStyle.Regular);
            //XFont boldFont = new XFont("Arial", 10, XFontStyle.Bold);

            //gfx.DrawString("Image Path: ", boldFont, XBrushes.Black, new XRect(50, 580, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table.Rows[0]["Path"], textFont, XBrushes.Black, new XRect(150, 580, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Camera Model: ", boldFont, XBrushes.Black, new XRect(50, 600, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table.Rows[0]["Exif_Model"], textFont, XBrushes.Black, new XRect(150, 600, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("F-Number: ", boldFont, XBrushes.Black, new XRect(50, 620, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString("" + (int)table.Rows[0]["Exif_FNumber"], textFont, XBrushes.Black, new XRect(150, 620, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Exposure Time: ", boldFont, XBrushes.Black, new XRect(50, 640, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString("" + (int)table.Rows[0]["Exif_ExposureTimeMS"], textFont, XBrushes.Black, new XRect(150, 640, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Date Time Created: ", boldFont, XBrushes.Black, new XRect(50, 660, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString("" + (DateTime)table.Rows[0]["Exif_DateTime"], textFont, XBrushes.Black, new XRect(150, 660, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("City: ", boldFont, XBrushes.Black, new XRect(50, 680, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table.Rows[0]["Iptc_City"], textFont, XBrushes.Black, new XRect(150, 680, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Date Time Created: ", boldFont, XBrushes.Black, new XRect(50, 700, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table.Rows[0]["Iptc_Caption"], textFont, XBrushes.Black, new XRect(150, 700, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Headline: ", boldFont, XBrushes.Black, new XRect(50, 720, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table.Rows[0]["Iptc_Headline"], textFont, XBrushes.Black, new XRect(150, 720, 100, 0), XStringFormats.BaseLineLeft);

            //gfx.DrawString("Photographer: ", boldFont, XBrushes.Black, new XRect(50, 740, 100, 0), XStringFormats.BaseLineLeft);
            //gfx.DrawString((string)table2.Rows[0]["FirstName"] + " " + (string)table2.Rows[0]["LastName"], textFont, XBrushes.Black, new XRect(150, 740, 100, 0), XStringFormats.BaseLineLeft);


            //string filename = "Reports\\Report for Picture " + (string)table.Rows[0]["Iptc_Headline"] + ".pdf";

            //pdf.Save(filename);

            //Process.Start(filename);
        }

    }
}
