using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace StudentsMongo
{
    public partial class student : System.Web.UI.Page
    {
        studentDetails details = new studentDetails();

        // To create a client connection to a running mongod instance and use the studentManSystem database.
        protected static IMongoClient client = new MongoClient("mongodb://localhost:27017");
        protected static IMongoDatabase database = client.GetDatabase("studentManSystem");
        // protected is accessible within the type and any derived types. 
        //static is used as A field initializer cannot reference a non-static field.

        // The page load event is triggered before the Load event for any controls.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clears all text boxes, method below
                ClearSearch();
            }

        }

        // Insert button
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // All details added to each text box are aaigned to 
            // each studentDetails variable.
            details.name = txtName.Text;
            details.email = txtEmail.Text;
            details.tNumber = txtTnumber.Text;
            details.password = txtPassword.Text;
            string result2 = details.feesPaid.ToString();
            result2 = txtFees.Text;
            details.college = txtCollege.Text;
            details.subject1 = txtSub1.Text;
            details.subject2 = txtSub2.Text;
            details.subject3 = txtSub3.Text;
            details.subject4 = txtSub4.Text;
            details.subject5 = txtSub5.Text;

            // insert method with the details parameter
            Insert(details);
        }

        // Insert method to store the student details to the database
        private void Insert(studentDetails details)
        {
            // Retrieve Students collection in the form of Bson document
            var collection = database.GetCollection<BsonDocument>("Students");
            // Conversion to DSON document
            BsonDocument document = details.ToBsonDocument();
            // InsertOne() used to insert one document.
            collection.InsertOne(document);
            // id from the document will be assigned to txtId.Text
            txtId.Text = document["_id"].ToString();

            // A method to manage editing options, setting some buttons to be enabled. see method below.
            EnableEditing();
            lblResults1.Text = "Students details have been added";
        }

        // Edit button
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        //Delete button
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        // ClearSearch button
        protected void btnClean_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        // Search Button
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtId.Text;

            if (search.Length == 0)
            {
                lblResults.Text = "Please enter the student tNumber";
            }
            else
            {
                lblResults.Text = string.Empty;

                // Search method used to find student details using the students id.
                Search(search);
            }

        }

        private void Search(string idStudent)
        {
            // To get access to the Students collection.
            var collection = database.GetCollection<BsonDocument>("Students");
            // This filters the Students collection to filter out the student id.
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(idStudent));
            // This result will get the fist id and if one doesn't exist it will return a default
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                // Conditional operator to return result or an empty string.
                txtName.Text = result["name"] != null ? result["name"].ToString() : string.Empty;
                txtEmail.Text = result["email"] != null ? result["email"].ToString() : string.Empty;
                txtTnumber.Text = result["tNumber"] != null ? result["tNumber"].ToString() : string.Empty;
                txtPassword.Text = result["password"] != null ? result["password"].ToString() : string.Empty;
                string result2 = details.feesPaid.ToString();
                result2 = txtFees.Text = result["feesPaid"] != null ? result["feesPaid"].ToString() : string.Empty;
                txtCollege.Text = result["college"] != null ? result["college"].ToString() : string.Empty;
                txtSub1.Text = result["subject1"] != null ? result["subject1"].ToString() : string.Empty;
                txtSub2.Text = result["subject2"] != null ? result["subject2"].ToString() : string.Empty;
                txtSub3.Text = result["subject3"] != null ? result["subject3"].ToString() : string.Empty;
                txtSub4.Text = result["subject4"] != null ? result["subject4"].ToString() : string.Empty;
                txtSub5.Text = result["subject5"] != null ? result["subject5"].ToString() : string.Empty;

                // A method to manage editing options, setting some buttons to be enabled. see method below.
                EnableEditing();
            }
            else
            {
                // returns if there is no studentId.
                lblResults.Text = "No Student " + idStudent;
                // Clears all text boxes, method below
                ClearSearch();
            }

        }

        // edit method used to make changes to a students details
        private void Edit()
        {
            var collection = database.GetCollection<BsonDocument>("Students");
            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(txtId.Text));

            details._id = ObjectId.Parse(txtId.Text);
            details.name = txtName.Text;
            details.email = txtEmail.Text;
            details.tNumber = txtTnumber.Text;
            details.password = txtPassword.Text;
            string result3 = details.feesPaid.ToString();
            result3 = txtFees.Text;
            details.college = txtCollege.Text;
            details.subject1 = txtSub1.Text;
            details.subject2 = txtSub2.Text;
            details.subject3 = txtSub3.Text;
            details.subject4 = txtSub4.Text;
            details.subject5 = txtSub5.Text;

            lblResults1.Text = "Students details have been updated";

            // Replaces a single document within the collection based on the filter.
            collection.ReplaceOne(filter, details.ToBsonDocument());
        }

        private void Delete()
        {
            var collection = database.GetCollection<BsonDocument>("Students");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(txtId.Text));

            // Removes a single document from a collection
            collection.DeleteOne(filter);

            ClearSearch();
            lblResults1.Text = "Students details have been deleted";

        }

        /// <summary>
        /// 
        /// </summary>
        private void MapReduce1()
        {
            string map = @"
                function() {
                    var students = this;
                    emit(students.ITT, { count: 1, totalFalse: students.feesPaid});
            }";

            string reduce = @"
                function(key, values) {
                    var result = {count: 0, totalFalse: 0 };

                    values.forEach(function(value){
                        result.count += value.count;
                        result.totalFalse += value.totalFalse;
                    });
            }";

            //var collection = database.GetCollection<BsonDocument>("Students");
            //var options = new MapReduceOptionsBuilder();
            //options.SetFinalize(finalize);
            //options.SetOutput(MapReduceOutput.Inline);
            //var results = collection.MapReduce(map, reduce, options);

            //foreach (var result in results.GetResults())
            //{
                //Console.WriteLine(result.ToJson());
            //}
            //var options = new MapReduceOptions<>();

        }

        // EnableEditing method used to set buttons to true or false (true enabling the button)
        private void EnableEditing()
        {
            lblResults.Text = string.Empty;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Enabled = true;
            btnSearch.Enabled = false;
        }

        // ClearSearch method used to clear the textboxes of any student details.
        private void ClearSearch()
        {
            txtName.Text = string.Empty;
            txtId.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTnumber.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtCollege.Text = string.Empty;
            txtFees.Text = string.Empty;
            txtSub1.Text = string.Empty;
            txtSub2.Text = string.Empty;
            txtSub3.Text = string.Empty;
            txtSub4.Text = string.Empty;
            txtSub5.Text = string.Empty;

            //enabling and disabling buttons.
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnInsert.Enabled = true;
            btnSearch.Enabled = true;

            lblResults1.Text = string.Empty;
        }

        private void testMethod()
        {
                //testing
        }

    }
}