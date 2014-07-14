using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    /// <summary>
    /// 类gps。
    /// </summary>
    public class gps
    {
        public gps()
        { }
        #region Model
        private int _id;
        private string _lng;
        private string _lat;
        private string _offset_x;
        private string _offset_y;
        private string _offset_lng;
        private string _offset_lat;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string offset_x
        {
            set { _offset_x = value; }
            get { return _offset_x; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string offset_y
        {
            set { _offset_y = value; }
            get { return _offset_y; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string offset_lng
        {
            set { _offset_lng = value; }
            get { return _offset_lng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string offset_lat
        {
            set { _offset_lat = value; }
            get { return _offset_lat; }
        }
        #endregion Model


        #region  Method

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public gps(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,lng,lat,offset_x,offset_y,offset_lng,offset_lat ");
            strSql.Append(" FROM gps ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                lng = ds.Tables[0].Rows[0]["lng"].ToString();
                lat = ds.Tables[0].Rows[0]["lat"].ToString();
                offset_x = ds.Tables[0].Rows[0]["offset_x"].ToString();
                offset_y = ds.Tables[0].Rows[0]["offset_y"].ToString();
                offset_lng = ds.Tables[0].Rows[0]["offset_lng"].ToString();
                offset_lat = ds.Tables[0].Rows[0]["offset_lat"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from gps");
            strSql.Append(" where id=@id ");

            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gps(");
            strSql.Append("lng,lat,offset_x,offset_y,offset_lng,offset_lat)");
            strSql.Append(" values (");
            strSql.Append("@lng,@lat,@offset_x,@offset_y,@offset_lng,@offset_lat)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@lng", SqlDbType.VarChar,50),
					new SqlParameter("@lat", SqlDbType.VarChar,50),
					new SqlParameter("@offset_x", SqlDbType.VarChar,50),
					new SqlParameter("@offset_y", SqlDbType.VarChar,50),
					new SqlParameter("@offset_lng", SqlDbType.VarChar,50),
					new SqlParameter("@offset_lat", SqlDbType.VarChar,50)};
            parameters[0].Value = lng;
            parameters[1].Value = lat;
            parameters[2].Value = offset_x;
            parameters[3].Value = offset_y;
            parameters[4].Value = offset_lng;
            parameters[5].Value = offset_lat;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gps set ");
            strSql.Append("lng=@lng,");
            strSql.Append("lat=@lat,");
            strSql.Append("offset_x=@offset_x,");
            strSql.Append("offset_y=@offset_y,");
            strSql.Append("offset_lng=@offset_lng,");
            strSql.Append("offset_lat=@offset_lat");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@lng", SqlDbType.VarChar,50),
					new SqlParameter("@lat", SqlDbType.VarChar,50),
					new SqlParameter("@offset_x", SqlDbType.VarChar,50),
					new SqlParameter("@offset_y", SqlDbType.VarChar,50),
					new SqlParameter("@offset_lng", SqlDbType.VarChar,50),
					new SqlParameter("@offset_lat", SqlDbType.VarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = lng;
            parameters[1].Value = lat;
            parameters[2].Value = offset_x;
            parameters[3].Value = offset_y;
            parameters[4].Value = offset_lng;
            parameters[5].Value = offset_lat;
            parameters[6].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gps ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public gps GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lng,lat,offset_x,offset_y,offset_lng,offset_lat ");
            strSql.Append(" FROM gps ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            gps model = new gps();  
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.lng = ds.Tables[0].Rows[0]["lng"].ToString();
                model.lat = ds.Tables[0].Rows[0]["lat"].ToString();
                model.offset_x = ds.Tables[0].Rows[0]["offset_x"].ToString();
                model.offset_y = ds.Tables[0].Rows[0]["offset_y"].ToString();
                model.offset_lng = ds.Tables[0].Rows[0]["offset_lng"].ToString();
                model.offset_lat = ds.Tables[0].Rows[0]["offset_lat"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public gps GetModel(string lng,string lat)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,lng,lat,offset_x,offset_y,offset_lng,offset_lat ");
            strSql.Append(" FROM gps ");
            strSql.Append(" where lng=@lng and lat=@lat");
            SqlParameter[] parameters = {
					new SqlParameter("@lng", SqlDbType.VarChar),
                    new SqlParameter("@lat", SqlDbType.VarChar)
            };
            parameters[0].Value = lng;
            parameters[1].Value = lat;
            gps model = new gps();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.lng = ds.Tables[0].Rows[0]["lng"].ToString();
                model.lat = ds.Tables[0].Rows[0]["lat"].ToString();
                model.offset_x = ds.Tables[0].Rows[0]["offset_x"].ToString();
                model.offset_y = ds.Tables[0].Rows[0]["offset_y"].ToString();
                model.offset_lng = ds.Tables[0].Rows[0]["offset_lng"].ToString();
                model.offset_lat = ds.Tables[0].Rows[0]["offset_lat"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM gps ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

