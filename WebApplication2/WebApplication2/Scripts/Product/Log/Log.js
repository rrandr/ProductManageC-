
    var ProdViewModel = function () {
        //Make the self as 'this' reference

        self.Log = ko.observableArray([]);


        GetLog(); // Call the Function which get all logs using ajax call



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


    };
    ko.applyBindings(new ProdViewModel());


