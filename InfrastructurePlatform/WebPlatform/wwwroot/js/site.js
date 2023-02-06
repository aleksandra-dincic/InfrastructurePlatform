var Site = {

}

Site.addPlatform = function() {

    var name = $("#newPlatformName").val();
    var version = $("#newPlatformVersion").val();
    var description = $("#newPlatformDescription").val();
    var photoUrl = $("#newPlatformPhotoUrl").val();

    var platform = {
        Name: name,
        Version: version,
        Description: description,
        PictureUrl: photoUrl
    };

    $.ajax({
        url: '/Platforms/CreatePlatform',
        type: 'POST',
        data: platform,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.updatePlatform = function() {

    var id = $("#editPlatformId").val();
    var name = $("#editPlatformName").val();
    var version = $("#editPlatformVersion").val();
    var description = $("#editPlatformDescription").val();
    var photoUrl = $("#editPlatformPhotoUrl").val();

    var platform = {
        Id: id,
        Name: name,
        Version: version,
        Description: description,
        PictureUrl: photoUrl
    };

    $.ajax({
        url: '/Platforms/UpdatePlatform',
        type: 'POST',
        data: platform,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.deletePlatform = function(id) {

    $.ajax({
        url: '/Platforms/DeletePlatform?platformId=' + id,
        type: 'POST',
        success: function(result) {
            window.location.href = "/Platforms/Index";
        },
        error: function(err) {
            window.location.href = "/Platforms/Index";
        }
    });
}

Site.addSystem = function() {

    var name = $("#newSystemName").val();
    var version = $("#newSystemVersion").val();
    var operatingSystem = $("#newSystemOperatingSystem").val();
    var services = $("#newSystemServices").val();
    var description = $("#newSystemDescription").val();

    var system = {
        Name: name,
        Version: version,
        Description: description,
        OperatingSystem: operatingSystem,
        PlatformsIds: services
    };

    $.ajax({
        url: '/Systems/CreateSystem',
        type: 'POST',
        data: system,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

Site.addServices = function() {

    var system = {
        Id: $("#systemId").val(),
        PlatformsIds: $("#newOperatingSystem").val()
    };

    $.ajax({
        url: '/Systems/AddServices',
        type: 'POST',
        data: system,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}


Site.deleteSystem = function(id) {

    $.ajax({
        url: '/Systems/DeleteSystem?systemId=' + id,
        type: 'POST',
        success: function(result) {
            window.location.href = "/Systems/Index";
        },
        error: function(err) {
            window.location.href = "/Systems/Index";
        }
    });
}

Site.updateSystem = function() {

    var id = $("#editSystemId").val();
    var name = $("#editSystemName").val();
    var version = $("#editSystemVersion").val();
    var description = $("#editSystemDescription").val();
    var operatingSystem = $("#editSystemOperatingSystem").val();

    var system = {
        Id: id,
        Name: name,
        Version: version,
        Description: description,
        OperatingSystem: operatingSystem
    };

    $.ajax({
        url: '/Systems/UpdateSystem',
        type: 'POST',
        data: system,
        success: function(result) {
            window.location.reload();
        },
        error: function(err) {
            window.location.reload();
        }
    });
}

