using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;


namespace ConsoleAppForAzure
{
    class Program
    {
        static void Main(string[] args)
        {
            StorageCredentials myStorageCredential = new StorageCredentials("firststoragerittik", "Kow6uv3yBGGrl4n4pvKmi5VSs5LsivTVVDhzUK5cI6DsU1zX8zIuusnJQrPP7vmVJc7ZrL3UEKrFTbJvI5Wh+w==");
            //Get the reference of the Storage Account 

            CloudStorageAccount storageaccount = new CloudStorageAccount(myStorageCredential, true);

            //Get the reference of the Storage Blob  c
            CloudBlobClient clientBlob = storageaccount.CreateCloudBlobClient();

            //Get the reference of the Container. The GetConainerReference doesn't make a request to the Blob Storage but the Create() & CreateIfNotExists() method does. 
            //The method CreateIfNotExists() could be use whether the Container exists or not  

            CloudBlobContainer container = clientBlob.GetContainerReference("firstcontainer");
            container.CreateIfNotExists();
            container.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });
            Console.WriteLine("Container got created successfully");

            CreateDownloadDeleteBlockBlob(container, "Pictures", "scenery");
            Console.WriteLine("Image has been created, Downloaded, Deleted successfully");
            Console.WriteLine("List blobs in container.");
            BlobContinuationToken blobContinuationToken = null;
            do
            {
                var results = container.ListBlobsSegmented(null, blobContinuationToken);

                // Get the value of the continuation token returned by the listing call.
                blobContinuationToken = results.ContinuationToken;
                foreach (IListBlobItem item in results.Results)
                {
                    Console.WriteLine(item.Uri);
                }
            } while (blobContinuationToken != null); // Loop while the continuation token is not null. 

            CloudTableClient cloudTableClient = storageaccount.CreateCloudTableClient();
            Console.WriteLine("Enter your table name:");
            string name = Console.ReadLine();
            CloudTable cloudTableContainer = cloudTableClient.GetTableReference(name);
            CreateTable(cloudTableContainer);
        }
        static void CreateDownloadDeleteBlockBlob(CloudBlobContainer container, string strDirectoryName, string strFileName)
        {

            CloudBlobDirectory directory = container.GetDirectoryReference(strDirectoryName);
            CloudBlockBlob blockblob = directory.GetBlockBlobReference(strFileName + ".jpg");
            blockblob.UploadFromFile("d:\\mahaCloud-Azure_Image.jpg");

            blockblob.DownloadToFile("d:\\mahaCloud-Azure_Image.jpg", FileMode.Create);
            //blockblob.DeleteIfExists();
        }

        public static void CreateTable(CloudTable table)
        {
            if (!table.CreateIfNotExists())
            {
                Console.WriteLine("Table {0} already exists", table);
                //return;
            }
            else
            {
                Console.WriteLine("Table {0} has been created successfully", table);
            }
        }

        public static void InsertRecordToTable(CloudTable table)
        {
            Console.WriteLine("Enter customer type");
            string customerType = Console.ReadLine();
            Console.WriteLine("Enter customer ID");
            string customerID = Console.ReadLine();
            Console.WriteLine("Enter customer name");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter customer details");
            string customerDetails = Console.ReadLine();
            Customer customerEntity = new Customer();

            customerEntity.customerType = customerType;
            customerEntity.customerID = Int32.Parse(customerID);
            customerEntity.customerDetails = customerDetails;
            customerEntity.customerName = customerName;
            customerEntity.AssignPartitionKey();
            customerEntity.AssignRowKey();

            Customer custRetrieveRecord = RetrieveRecord(table, customerType, customerID);

            if (custRetrieveRecord == null)
            {
                TableOperation tableOperation = TableOperation.Insert(customerEntity);
                table.Execute(tableOperation);
                Console.WriteLine("Record inserted");
            }
            else
            {
                Console.WriteLine("Record exists");
            }
        }

        public static Customer RetrieveRecord(CloudTable cloudTable, string partitionKey, string rowKey)
        {
            TableOperation tableOperation = TableOperation.Retrieve<Customer>(partitionKey, rowKey);
            TableResult tableResult = cloudTable.Execute(tableOperation);
            return tableResult.Result as Customer;
        }

        public static void UpdateRecordInTable(CloudTable table)
        {
            Console.WriteLine("Enter customer type");
            string customerType = Console.ReadLine();
            Console.WriteLine("Enter customer ID");
            string customerID = Console.ReadLine();
            Console.WriteLine("Enter customer name");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter customer details");
            string customerDetails = Console.ReadLine();

            Customer customerEntity = RetrieveRecord(table, customerType, customerID);

            if(customerEntity !=null)
            {
                customerEntity.customerDetails = customerDetails;
                customerEntity.customerID = Convert.ToInt32(customerID);
                customerEntity.customerName = customerName;

                TableOperation tableOperation = TableOperation.Replace(customerEntity);
                table.Execute(tableOperation);
                Console.WriteLine("Record updated");
            }
            else
            {
                Console.WriteLine("Record does not exists");
            }
        }
    }
}
