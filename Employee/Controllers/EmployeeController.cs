using Employee.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        string Connection = @"Data Source=DESKTOP-1EUO5KU;Initial Catalog=BTreeSystem;Integrated Security=True";
        // GET: Employee on the employee
        public ActionResult Index()
        { 
            List<EmployeeModel> employees = new List<EmployeeModel>();
            EmployeeModel employeeModel = null;
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ListEmployee";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            sqlcon.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    employeeModel = new EmployeeModel();
                    employeeModel.EmpId = int.Parse(sqlDataReader["EmpId"].ToString());
                    employeeModel.EmpName = sqlDataReader["EmpName"].ToString();
                    employeeModel.ContactNo = sqlDataReader["ContactNo"].ToString();
                    employeeModel.Address = sqlDataReader["Address"].ToString();
                    employeeModel.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                    employeeModel.DEPT = sqlDataReader["DEPT"].ToString();
                    employeeModel.City = sqlDataReader["City"].ToString();
                    employeeModel.RollName = sqlDataReader["RollName"].ToString();
                    employeeModel.ProjectName = sqlDataReader["ProjectName"].ToString();
                    employees.Add(employeeModel);
                }
            }
            sqlcon.Close();

            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeModel employeeModel = GetEmployeeDetails(id);


            return View(employeeModel);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection sqlcon = new SqlConnection();
                sqlcon.ConnectionString = Connection;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "InsertEmployee";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                cmd.Parameters.AddWithValue("@ContactNo", employeeModel.ContactNo);
                cmd.Parameters.AddWithValue("@Address", employeeModel.Address);
                cmd.Parameters.AddWithValue("@JoiningDate", employeeModel.JoiningDate);
                cmd.Parameters.AddWithValue("@DEPT",employeeModel.DEPT);
                cmd.Parameters.AddWithValue("@city",employeeModel.City);
                cmd.Parameters.AddWithValue("@RollName",employeeModel.RollName);
                cmd.Parameters.AddWithValue("@projectName",employeeModel.ProjectName);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeModel employeeModel = GetEmployeeDetails(id);
            return View(employeeModel);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel employeeModel)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection sqlcon = new SqlConnection();
                sqlcon.ConnectionString = Connection;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EmployeeUpdate";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@EmpId", id);
                cmd.Parameters.AddWithValue("@EmpName", employeeModel.EmpName);
                cmd.Parameters.AddWithValue("@ContactNo", employeeModel.ContactNo);
                cmd.Parameters.AddWithValue("@Address", employeeModel.Address);
                cmd.Parameters.AddWithValue("@JoiningDate", employeeModel.JoiningDate);
                cmd.Parameters.AddWithValue("@DEPT", employeeModel.DEPT);
                cmd.Parameters.AddWithValue("@city", employeeModel.City);
                cmd.Parameters.AddWithValue("@RollName", employeeModel.RollName);
                cmd.Parameters.AddWithValue("@projectName", employeeModel.ProjectName);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeModel employeeModel = GetEmployeeDetails(id);
            return View(employeeModel);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EmployeeModel employeeModel)
        {
            try
            {
                // TODO: Add delete logic here
                SqlConnection sqlcon = new SqlConnection();
                sqlcon.ConnectionString = Connection;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@EmpId", id);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private EmployeeModel GetEmployeeDetails(int id)
        { EmployeeModel employeeModel = new EmployeeModel();
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = Connection;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "EmployeeDetail";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Connection = sqlcon;
            cmd.Parameters.AddWithValue("@EmpId", id);
            sqlcon.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            if(sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    employeeModel.EmpId = int.Parse(sqlDataReader["EmpId"].ToString());
                    employeeModel.EmpName = sqlDataReader["EmpName"].ToString();
                    employeeModel.ContactNo = sqlDataReader["ContactNo"].ToString();
                    employeeModel.Address = sqlDataReader["Address"].ToString();
                    employeeModel.JoiningDate = sqlDataReader["JoiningDate"].ToString();
                    employeeModel.DEPT = sqlDataReader["DEPT"].ToString();
                    employeeModel.City = sqlDataReader["City"].ToString();
                    employeeModel.RollName = sqlDataReader["RollName"].ToString();
                    employeeModel.ProjectName = sqlDataReader["ProjectName"].ToString();

                  }
            }
            sqlcon.Close();
            return employeeModel;
        }
        
    }
}
