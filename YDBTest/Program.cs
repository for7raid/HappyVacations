using Google.Cloud.Firestore;
using HappyVacations.Models;

Console.WriteLine("Hello, World!");


/*
 
 const firebaseConfig = {
  apiKey: "AIzaSyA4G8UE1E4noKHoG4uORUhd7aUS9XUmX-4",
  authDomain: "happy-vacation-test.firebaseapp.com",
  projectId: "happy-vacation-test",
  storageBucket: "happy-vacation-test.appspot.com",
  messagingSenderId: "859562352554",
  appId: "1:859562352554:web:ccaa4478df6d638fec15d3"
};
 */

var firebaseConfig = new
{
    apiKey = "AIzaSyA4G8UE1E4noKHoG4uORUhd7aUS9XUmX-4",
    authDomain = "happy-vacation-test.firebaseapp.com",
    projectId = "happy-vacation-test",
    storageBucket = "happy-vacation-test.appspot.com",
    messagingSenderId = "859562352554",
    appId = "1:859562352554:web:ccaa4478df6d638fec15d3"
};

FirestoreDb db = FirestoreDb.Create(firebaseConfig.projectId);
Console.WriteLine("Created Cloud Firestore client with project ID: {0}", firebaseConfig.projectId);

var team = new Team { Name = "adacta", Id = "sdf323asdf" };

// Create a document with a random ID in the "users" collection.
CollectionReference collection = db.Collection("users");
DocumentReference document = await collection.AddAsync(new { Name = new { First = "Ada", Last = "Lovelace" }, Born = 1815 });

// A DocumentReference doesn't contain the data - it's just a path.
// Let's fetch the current document.
DocumentSnapshot snapshot = await document.GetSnapshotAsync();

// We can access individual fields by dot-separated path
Console.WriteLine(snapshot.GetValue<string>("Name.First"));
Console.WriteLine(snapshot.GetValue<string>("Name.Last"));
Console.WriteLine(snapshot.GetValue<int>("Born"));

// Or deserialize the whole document into a dictionary
Dictionary<string, object> data = snapshot.ToDictionary();
Dictionary<string, object> name = (Dictionary<string, object>)data["Name"];
Console.WriteLine(name["First"]);
Console.WriteLine(name["Last"]);

// See the "data model" guide for more options for data handling.

// Query the collection for all documents where doc.Born < 1900.
Query query = collection.WhereLessThan("Born", 1900);
QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
{
    string firstName = queryResult.GetValue<string>("Name.First");
    string lastName = queryResult.GetValue<string>("Name.Last");
    int born = queryResult.GetValue<int>("Born");
    Console.WriteLine($"{firstName} {lastName}; born {born}");
}


Console.WriteLine("Done");