using Microsoft.Data.SqlClient;
using PaddleSprt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PaddleSprt.DAL
{
    public class CRUD
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["PadSport"].ToString());

        public List<Booking> GetBookings()
        {

            SqlCommand cmd = new SqlCommand("spBooking", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            List<Booking> bookingList = new List<Booking>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                Booking booking = new Booking();

                var day = booking.timeSlot.Day;
                day = int.Parse(dataRow["timeSlot"].ToString());

                booking.playerID = int.Parse(dataRow["playerID"].ToString());
                booking.name = dataRow["name"].ToString();
                booking.phone = dataRow["phone"].ToString();
                booking.Playerprice = int.Parse(dataRow["Playerprice"].ToString());
                booking.courtID = int.Parse(dataRow["courtID"].ToString());
                booking.spID = int.Parse(dataRow["spID"].ToString());

                bookingList.Add(booking);
            }
            return bookingList;
        }

        public List<SportCenter> GetSportCenters()
        {
            SqlCommand command = new SqlCommand("spSpCenters", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            dataAdapter.UpdateCommand.CommandType = CommandType.StoredProcedure;

            List<SportCenter> sportCenterList = new List<SportCenter>();

            foreach (DataRow dataRow in dataTable.Rows)
            {

            }
            return sportCenterList;
        }
    }
}
