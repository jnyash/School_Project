using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Configuration; /*behöver för att hämta värden från web.config*/
using System.Data;
using System.Data.Common;


/*Dont forget to download and install EnterpriseLibrary from Extensions options */

namespace PING_PONG
{
    public class DataAccessor
    {
        // FirstConn is the name we give to our connectionString, to change it go to file Web.config and change the name there first
        public static string conn = ConfigurationManager.ConnectionStrings["FirstConn"].ConnectionString;

        //sqlDatabase är objektet som sköter kommunikationen med databasen
        public static SqlDatabase sqlDatabase = new SqlDatabase(conn);

        /* Metod to call stored procedure Usp_ShowAll_Person */
        public static DataSet Usp_Show_Person(int pers)
        {
            try
            {
                DbCommand cmd = sqlDatabase.GetStoredProcCommand("Usp_Show_Person");
                sqlDatabase.AddInParameter(cmd, "@ID ", DbType.Int32, pers);

                //Skapa ett dataset
                DataSet dsData = sqlDatabase.ExecuteDataSet(cmd);
                //Retunera ett dataset
                return dsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_Insert_Person */
        public static int Usp_Insert_Person(string vchFirstName, string vchLastName, string SSN, string vchEmail, string vchPhone, string vchtypename, string vchAdress, string vchCity, int intZIP)
        {
            try
            {
                DbCommand sacmd = sqlDatabase.GetStoredProcCommand("Usp_Insert_Person");

                sqlDatabase.AddInParameter(sacmd, "@vchFirstName ", DbType.String, vchFirstName);
                sqlDatabase.AddInParameter(sacmd, "@vchLastName", DbType.String, vchLastName);
                sqlDatabase.AddInParameter(sacmd, "@SSN", DbType.String, SSN);
                sqlDatabase.AddInParameter(sacmd, "@vchEmail", DbType.String, vchEmail);
                sqlDatabase.AddInParameter(sacmd, "@vchPhone", DbType.String, vchPhone);
                sqlDatabase.AddInParameter(sacmd, "@vchtypename", DbType.String, vchtypename);
                sqlDatabase.AddInParameter(sacmd, "@vchAdress", DbType.String, vchAdress);
                sqlDatabase.AddInParameter(sacmd, "@vchCity", DbType.String, vchCity);
                sqlDatabase.AddInParameter(sacmd, "@intZIP", DbType.Int32, intZIP);

                int intInsertResult = sqlDatabase.ExecuteNonQuery(sacmd);
                return intInsertResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_AddPersGroup */
        public static int Usp_AddPersGroup(int Pers_ID, int Group_ID)
        {
            try
            {
                DbCommand ADPCmd = sqlDatabase.GetStoredProcCommand("Usp_AddPersGroup");

                sqlDatabase.AddInParameter(ADPCmd, "@Pers_ID ", DbType.Int32, Pers_ID);
                sqlDatabase.AddInParameter(ADPCmd, "@Group_ID", DbType.Int32, Group_ID);

                int intADPCmdResult = sqlDatabase.ExecuteNonQuery(ADPCmd);
                return intADPCmdResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /* Metod to call stored procedure Usp_booking */
        public static int Usp_booking(string day, string time, string vchGroupNamn)
        {
            try
            {
                DbCommand BCmd = sqlDatabase.GetStoredProcCommand("Usp_booking");

                sqlDatabase.AddInParameter(BCmd, "@day ", DbType.String, day);  // DATE FORMAT HOW?
                sqlDatabase.AddInParameter(BCmd, "@time", DbType.String, time);
                sqlDatabase.AddInParameter(BCmd, "@vchGroupNamn", DbType.String, vchGroupNamn);

                int intBooResult = sqlDatabase.ExecuteNonQuery(BCmd);
                return intBooResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_Update_xTime */
        public static int Usp_Update_xTime(string zDay, string zTime, string vchGroupNamn)
        {
            try
            {
                DbCommand UxTCmd = sqlDatabase.GetStoredProcCommand("Usp_Update_xTime");

                sqlDatabase.AddInParameter(UxTCmd, "@zDay ", DbType.String, zDay);  // DATE FORMAT HOW?
                sqlDatabase.AddInParameter(UxTCmd, "@zTime", DbType.String, zTime);
                sqlDatabase.AddInParameter(UxTCmd, "@vchGroupNamn", DbType.String, vchGroupNamn);

                int intUpTimeResult = sqlDatabase.ExecuteNonQuery(UxTCmd);
                return intUpTimeResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_Cancel */
        public static int Usp_Cancel(string vchGroupNamn)
        {
            try
            {
                DbCommand Ccmd = sqlDatabase.GetStoredProcCommand("Usp_Cancel");

                sqlDatabase.AddInParameter(Ccmd, "@vchGroupNamn", DbType.String, vchGroupNamn);

                int intCResult = sqlDatabase.ExecuteNonQuery(Ccmd);
                return intCResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_Create_NewGroup */
        public static int Usp_Create_NewGroup(string vchGroupNamn, string vchGroup)
        {
            try
            {
                DbCommand CNGCmd = sqlDatabase.GetStoredProcCommand("Usp_Create_NewGroup");

                sqlDatabase.AddInParameter(CNGCmd, "@vchGroup ", DbType.String, vchGroup);
                sqlDatabase.AddInParameter(CNGCmd, "@vchGroupNamn", DbType.String, vchGroupNamn);

                int intCNGResult = sqlDatabase.ExecuteNonQuery(CNGCmd);
                return intCNGResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Metod to call stored procedure Usp_Delete_Group */
        public static int Usp_Delete_Group(int Group_Id)
        {
            try
            {
                DbCommand DGCmd = sqlDatabase.GetStoredProcCommand("Usp_Delete_Group");

                sqlDatabase.AddInParameter(DGCmd, "@Group_Id", DbType.Int32, Group_Id);

                int intDGResult = sqlDatabase.ExecuteNonQuery(DGCmd);
                return intDGResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_Delete_User */
        public static int Usp_Delete_User(int ID)
        {
            try
            {
                DbCommand DSCmd = sqlDatabase.GetStoredProcCommand("Usp_Delete_User");

                sqlDatabase.AddInParameter(DSCmd, "@ID", DbType.Int32, ID);

                int intDSResult = sqlDatabase.ExecuteNonQuery(DSCmd);
                return intDSResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_DelPersGroup */
        public static int Usp_DelPersGroup(int Pers_ID)
        {
            try
            {
                DbCommand DPGCmd = sqlDatabase.GetStoredProcCommand("Usp_DelPersGroup");

                sqlDatabase.AddInParameter(DPGCmd, "@Pers_ID", DbType.Int32, Pers_ID);

                int intDPGResult = sqlDatabase.ExecuteNonQuery(DPGCmd);
                return intDPGResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /* Metod to call stored procedure Usp_New_GroupTypes */
        public static int Usp_New_GroupTypes(string vchGroup)
        {
            try
            {
                DbCommand NGTCmd = sqlDatabase.GetStoredProcCommand("Usp_Update_GroupType");

                sqlDatabase.AddInParameter(NGTCmd, "@vchGroup ", DbType.String, vchGroup);

                int intNGTResult = sqlDatabase.ExecuteNonQuery(NGTCmd);
                return intNGTResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Metod to call stored procedure Usp_New_xTypes */
        public static int Usp_New_xTypes(string vchtypename)
        {
            try
            {
                DbCommand NxTCmd = sqlDatabase.GetStoredProcCommand("Usp_New_xTypes");

                sqlDatabase.AddInParameter(NxTCmd, "@vchtypename", DbType.String, vchtypename);

                int intNxTResult = sqlDatabase.ExecuteNonQuery(NxTCmd);
                return intNxTResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Metod to call stored procedure Usp_PersGroup */
        public static DataSet Usp_PersGroup(int Group_Id)
        {
            try
            {
                DbCommand PGCmd = sqlDatabase.GetStoredProcCommand("Usp_PersGroup");

                sqlDatabase.AddInParameter(PGCmd, "@Group_Id", DbType.Int32, Group_Id);

                DataSet dsMem = sqlDatabase.ExecuteDataSet(PGCmd);
                return dsMem;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /* Metod to call stored procedure Usp_Update_GroupType */
        public static int Usp_Update_GroupType(string vchGroup, string vchGroupNamn)
        {
            try
            {
                DbCommand UGTCmd = sqlDatabase.GetStoredProcCommand("Usp_Update_GroupType");

                sqlDatabase.AddInParameter(UGTCmd, "@vchGroup ", DbType.String, vchGroup);
                sqlDatabase.AddInParameter(UGTCmd, "@vchGroupNamn", DbType.String, vchGroupNamn);

                int intUGTResult = sqlDatabase.ExecuteNonQuery(UGTCmd);
                return intUGTResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Metod to call stored procedure Usp_Update_MembershipType */
        public static int Usp_Update_MembershipType(int Id, string vchtypename)
        {
            try
            {
                DbCommand UMTCmd = sqlDatabase.GetStoredProcCommand("Usp_Update_MembershipType");

                sqlDatabase.AddInParameter(UMTCmd, "@vchtypename", DbType.String, vchtypename);
                sqlDatabase.AddInParameter(UMTCmd, "@Id", DbType.Int32, Id);

                int intUMTResult = sqlDatabase.ExecuteNonQuery(UMTCmd);
                return intUMTResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /* Metod to call stored procedure Usp_Update_Persons */
        public static int Usp_Update_Persons(int ID, string vchFirstName, string vchLastName, string vchEmail, string vchPhone, string vchAdress, string vchCity, int intZIP)
        {
            try
            {
                DbCommand UPCmd = sqlDatabase.GetStoredProcCommand("Usp_Update_Persons");

                sqlDatabase.AddInParameter(UPCmd, "@ID", DbType.Int32, ID);
                sqlDatabase.AddInParameter(UPCmd, "@vchFirstName ", DbType.String, vchFirstName);
                sqlDatabase.AddInParameter(UPCmd, "@vchLastName", DbType.String, vchLastName);
                sqlDatabase.AddInParameter(UPCmd, "@vchEmail", DbType.String, vchEmail);
                sqlDatabase.AddInParameter(UPCmd, "@vchPhone", DbType.String, vchPhone);
                sqlDatabase.AddInParameter(UPCmd, "@vchAdress", DbType.String, vchAdress);
                sqlDatabase.AddInParameter(UPCmd, "@vchCity", DbType.String, vchCity);
                sqlDatabase.AddInParameter(UPCmd, "@intZIP", DbType.Int32, intZIP);

                int intUPResult = sqlDatabase.ExecuteNonQuery(UPCmd);
                return intUPResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Metod to call stored procedure Usp_clogin */
        public static DataSet Usp_clogin(string cusername, string cpassword)
        {
            try
            {
                DbCommand ClogCmd = sqlDatabase.GetStoredProcCommand("Usp_clogin");

                sqlDatabase.AddInParameter(ClogCmd, "@cusername", DbType.String, cusername);
                sqlDatabase.AddInParameter(ClogCmd, "@cpassword", DbType.String, cpassword);
                DataSet intcLog = sqlDatabase.ExecuteDataSet(ClogCmd);
                return intcLog;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*Metod to call stored procedure Usp_BookningStatus */
        public static DataSet Usp_BookingStatus(string vchGroupNamn)
        {
            try
            {
                DbCommand BScmd = sqlDatabase.GetStoredProcCommand("Usp_BookningStatus");

                sqlDatabase.AddInParameter(BScmd, "@vchGroupNamn", DbType.String, vchGroupNamn);
                //Skapa ett dataset
                DataSet BSData = sqlDatabase.ExecuteDataSet(BScmd);
                //Retunera ett dataset
                return BSData;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /* Metod to call stored procedure Usp_Book_Tabel */
        public static DataSet Usp_Book_Tabel()
        {
            try
            {
                DbCommand BTCmd = sqlDatabase.GetStoredProcCommand("Usp_Book_Tabel");
                DataSet dsData1 = sqlDatabase.ExecuteDataSet(BTCmd);

                return dsData1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

/**********************************************************************************************************************************************************************************************************
*       List of procedure            *                   Beskrivning                                *            Parameter i Procedure                                                                    *
***********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Update_xTime]          *  Uppdatera  xTime tabell                                     * @zDay date,@zTime  varchar(15),@vchGroupNamn varchar(60)                                            *
 **********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_AddPersGroup]          *  lägga till Medlemmer i en grupp                             * @Pers_ID int,@Group_ID INT                                                                          *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Book_Tabel]            *  Visa bokning tabel                                          * @vchGroupNamn varchar (40),@zDay DATE                                                               *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_booking]               *  Boka dag och tid                                            * @day date,@time varchar(15),@vchGroupNamn varchar(60)                                               *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Cancel]                *  Avbokning                                                   * @vchGroupNamn	varchar(100)                                                                                          *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Create_NewGroup]       *  Skapa en ny grupp                                           * @vchGroupNamn varchar(60),@vchGroup		VARCHAR(40)                                               *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Delete_Group]          *  Radera en ny grupp                                          * @Group_Id	int                                                                                       *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Delete_User]           *  Tar bort en medlem från Persons / Adresses Table            * @ID int                                                                                             *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_DelPersGroup]          *  Tar bort en Medlem från gruppen                             * @Pers_ID int,@Group_ID	int                                                                       *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Insert_Person]         *  Lägga till en medlem i Persons / Adresses / xTypes Table    * @vchFirstName varchar(100),@vchLastName varchar(100),@SSN varchar(11),@vchEmail varchar(100),       *
 *                                   *                                                              * @vchPhone varchar(100),@vchtypename varchar(40),@vchAdress varchar(100),@vchCity varchar(100),      *
 *                                   *                                                              * @intZIP int,                                                                                        *
 **********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_New_GroupTypes]        *  Lägga till en ny kategori  i Group_types                    * @vchGroup VARCHAR(40)                                                                               *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_New_xTypes]            *  Lägga till en ny kategori  i xTypes                         * @vchtypename VARCHAR(40)                                                                            *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_PersGroup]             *  Sök efter personer som är med i en grupp enligt gruppsnamn  * @vchGroupNamn VARCHAR(40)                                                                           *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Show_Person]           *  Visa kontaktuppgift på en person                            * EMPTY                                                                                               *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Update_GroupType]      *  Uppdatera Group_Typ för Groups                              * @vchGroup varchar(40), @vchGroupNamn varchar(60)                                                    *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Update_MembershipType] *  Uppdatera Medlemnsskap_Typ                                  * @Id int, @vchtypename varchar(40)                                                                   *
 * ********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_Update_Persons]        *  Uppdatera Persons och Adress Tabel                          * @vchFirstName VARCHAR(100),@vchLastName VARCHAR(100),@vchEmail VARCHAR(100),@vchPhone VARCHAR(100), *
 *                                   *                                                              * @ID int,@ID int,@vchAdress VARCHAR(100),@vchCity VARCHAR(100),@intZIP INT                           *
 **********************************************************************************************************************************************************************************************************
 * [dbo].[Usp_clogin]                *  login uppgift på (admin/pass)                               * @cusername	varchar(100),@cpassword	varchar(100)                                                  *
 **********************************************************************************************************************************************************************************************************
 * Usp_ShowGroupNam_Type             * Visa  group name and group type                              * @Group_Id                                                                                           *
 ********************************************************************************************************************************************************************************************************** 
 * Usp_BookningStatus                * Visa lista på  Bookning_id i                                 * @vchGroupNamn                                                                                       *
 ********************************************************************************************************************************************************************************************************** 
 *
 **********************************************************************************************************************************************************************************************************/