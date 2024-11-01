# Progi Challenge for Nathan Sicard

This project corresponds to the coding challenge for Progi. It provides a basic C# API that calculates the cost and fees for a given price and vehicle type. A basic Vue frontend using Typescript allows the user to execute these calculations.


## Architecture

### Frontend
The frontend presents the data to the user along with basic input validation before sending requests.

### Backend
The backend is a simple API with models for vehicles and fee breakdowns, a controller for the bid endpoint, and a utils folder.
The abstract Vehicle class provides the properties and fee calculation methods which are shared between the CommonVehicle and LuxuryVehicle classes. It also provides a base constructor requiring the initialization of properties which are not shared between vehicle types. The CommonVehicle and LuxuryVehicle classes set their respective property values via the parent's constructor. The utils folder contains the FeeCalculator class which is used to assemble the FeeBreakdown object from a Vehicle object in order to send it to the client. This architecture was chosen in order to abstract the fee aggregation logic from the controller and model classes.

### Tests
The tests are separated into two sections: The Vehicle tests which verify the CommonVehicle and LuxuryVehicle functions, and the FeeCalculator tests which verify the generation of FeeBreakdown objects through the FeeCalculator object.

## Possible improvements
### General
Currently, calculations are run in the backend. However, the estimates are simple and do not specifically require backend ressources to operate. Therefore, we should consider moving the calculation logic to the frontend. This is supported by the current need to send a web request every time the price or vehicle type is updated. Moving the calculations to the frontend would then only require a single request to the backend to load the page at the beginning.

Prices should probably be capped to a maximum however they are not currently capped as it wasn't an explicit requirement. A minimum of 0$ (free) was included.

### Frontend
Given the current architecture, an alternative allowing a reduction of server requests to achieve a similar result would be to include a debounce/throttle to the update requests. By updating the price estimates based on the last change in the last 200ms (interval tbd), we would allow a seemingly realtime experience for the user while reducing the request load to the server.

The frontend would need an improved UI/look. I did not focus on that portion considering it was not mentioned in the requirements. Proper CSS files along with custom input fields would greatly improve the look of the application.

### Backend
I am not quite satisfied with the current backend architecture. I have the impression that there should be a cleaner way to implement the Vehicle class. While I support the current use of abstraction in order to reuse common logic, I feel like the properties could be reworked in some way (based on instinct).

The controller class could likely be cleaned up by moving the validation logic that is associated with the vehicle/fee logic elsewhere (whether into these classes directly or in some form of intermediary class). The "if" logic instantiating the vehicle object used to calculate fees is too rigid in my opinion and could likely be replaced by a method providing a conversion along with error handling in the case of a vehicle type that doesn't exist. However, safeguards would need to be in place to ensure security if classes are to be parsed from user input.

The FeeCalculator currently acts more like a static class and could be changed as such for the moment. Depending on whether there are parameters that could be added for a given calculation (or set of calculations) such as discounts or the addition of other bid "types" (more complex vehicles, added properties which would require extra methods and properties), it could be interesting to include an IFeeCalculator interface allowing extensions towards other classes (as well as looser coupling).

Validation could also potentially be considered within the fee calculation methods as the Vehicle object itself could be considered responsible for managing the validity of its data.

### Tests
In hindsight, the CommonVehicleTest and LuxuryVehicleTest test classes should probably be combined into one single VehicleTest class. While they do differ in the specific subclass being tested, they are thematically identical and share input signatures. The refactored VehicleTest class would therefore use the MemberData decorator rather than InlineData in order to avoid the repitition of functionnality that currently exists between the test classes.

Testing for edge cases and errors should be included in the future.