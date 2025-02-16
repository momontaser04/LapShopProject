var ClsSettings = {
    GetAll: function () {
        Helper.AjaxCallGet("https://localhost:7075/api/Setting", {}, "json",
            function (data) {
                console.log(data); // Verify the object structure

                // Dynamically update the href attributes
                $("#LinkFacebook").attr("href", data.faceBookLink);
                $("#LinkLinkedin").attr("href", data.linkedIn);
                $("#LinkGithub").attr("href", data.githubLink);
      
              


                // Optionally set other links if needed
                $("#LinkYouTube").attr("href", data.youtubeLink);
            },
            function () {
                console.error("Failed to fetch settings.");
            }
        );
    }
};

// Fetch settings when the page loads
ClsSettings.GetAll();
