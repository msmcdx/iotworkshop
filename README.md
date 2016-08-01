# Source code for IOT Workshop

This is a source code for [Internet Of Things Workshop](http://iotworkshop.azurewebsites.net) as a result of exploring [Microsoft SDK](https://www.microsoft.com/en-us/cloud-platform/internet-of-things) for working with IoT.

Source code as zip file is available [**here**](http://iotworkshop.azurewebsites.net/Download).

![](https://iotworkshop.blob.core.windows.net/pics/PictureIotWorkshopHomePage.png)
Inspired by [Connect the Dots](http://aka.ms/iot-ctd-field-labs) this workshop encapsulate the whole IOT lifecycle (getting data from device to web and then delivered to the client):

- Web Interface (this project can be used as a hosting solution)
- Client for Windows 10 (coming in separate branch)
- Client for Raspberry PI on Windows and Linux (coming in separate branch)

----------

All clients communicate with Web interface [directly](http://www.asp.net/web-api) or indirectly via Azure [Event Hubs](https://azure.microsoft.com/en-us/services/event-hubs/ "Event Hubs") / [Azure IoT Hub](https://azure.microsoft.com/en-us/documentation/articles/iot-hub-what-is-iot-hub/).

If you want to start with IoT development, you can start by choosing [your path](http://iotworkshop.azurewebsites.net/Docs). Path can be done **independently** of each other. If you want to learn building the client / server / client, start with **first one** and then continue with next.

----------

This project uses [Pipeline](https://github.com/miguelcastro67/pipeline-framework) approach, explained and authored by [Miguel Castro](https://github.com/miguelcastro67). Some of the helpers in the code are authored by community contributors:


-  memory default implementation [InMemoryCache](http://stackoverflow.com/questions/343899/how-to-cache-data-in-a-mvc-application)
-  extension for Enums [EnumExtensions](http://kirillosenkov.blogspot.com/2007/09/making-c-enums-more-usable-parse-method.html)
-  Object Query Extensions [ObjectQueryExtensions](http://www.nearinfinity.com/blogs/joe_ferner/type-safe_entity_framework_inc.html)
-  HTML extensions - available [on ASP.NET page](http://www.asp.net/mvc/overview/older-versions-1/views/using-the-tagbuilder-class-to-build-html-helpers-cs)

If you want to *contribute*, create pull request and we will review your request.

For any Workshop related question, please, reach to us out via About page on [IoT Workshop Homepage](http://iotworkshop.azurewebsites.net/Home/About). 