
var ProdViewModel = function () {
    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI
    self.ProdID = ko.observable("0");
    self.ProdName = ko.observable("");
    self.Price = ko.observable("");
    self.Description = ko.observable("");

    //The Object which stored data entered in the observables
    var ProdData = {
        ProdID: self.ProdID,
        ProdName: self.ProdName,
        Price: self.Price,
        Description: self.Description

    };

    //Declare an ObservableArray for Storing the JSON Response
    self.Product = ko.observableArray([]);
    self.Log = ko.observableArray([]);

    GetProduct(); //Call the Function which gets all records using ajax call
    GetLog(); // Call the Function which get all logs using ajax call


    //Function to perform POST (insert Product) operation
    self.save = function () {
        //Ajax call to Insert the Product
        $.ajax({
            type: "POST",
            url: "/api/ProductAPI",
            data: ko.toJSON(ProdData), //Convert the Observable Data into JSON
            contentType: "application/json",
            success: function (data) {
                alert("Record Added Successfully");
                self.ProdID(data.ProdID);
                alert("The New Product Id :" + self.ProdID());
                GetProduct();//Refresh the Table
                GetLog();
            },
            error: function () {
                alert("Failed");
            }
        });
        //Ends Here
    };

    self.update = function () {
        var url = "/api/ProductAPI/" + self.ProdID();
        alert(url);
        $.ajax({
            type: "PUT",
            url: url,
            data: ko.toJSON(ProdData),
            contentType: "application/json",
            success: function (data) {
                alert("Record Updated Successfully");
                GetProduct();//Refresh the Table
                GetLog();
            },
            error: function (error) {
                alert(error.status + "<!----!>" + error.statusText);
            }
        });
    };

    //Function to perform DELETE Operation
    self.deleterec = function (product) {
        $.ajax({
            type: "DELETE",
            url: "/api/ProductAPI/" + product.ProdID,
            success: function (data) {
                alert("Record Deleted Successfully");
                GetProduct();//Refresh the Table
                GetLog();
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
        // alert("Clicked" + Product.EmpNo)
    };

    //Function to Read All Product
    function GetProduct() {
        //Ajax Call Get All Product Records
        $.ajax({
            type: "GET",
            url: "/api/ProductAPI",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Product(data); //Put the response in ObservableArray
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
        //Ends Here
    }

    function GetLog() {
        //Ajax Call Get All Product Records
        $.ajax({
            type: "GET",
            url: "/api/LogAPI",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                self.Log(data); //Put the response in ObservableArray
            },
            error: function (error) {
                alert(error.status + "<--and--> " + error.statusText);
            }
        });
        //Ends Here
    }

    //Function to Display record to be updated
    self.getproductselected = function (product) {
        self.ProdID(product.ProdID),
        self.ProdName(product.ProdName),
        self.Price(product.Price),
        self.Description(product.Description)
    };


};
ko.applyBindings(new ProdViewModel());
