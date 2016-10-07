The source code samples have been tested with Visual Studio 2003 and 2005,
but should also work with little or no changes in Visual Studio 2002.
Unzip the book's source code zip file into a folder on your hard drive.
Make sure you aren't using a drive with a mapped letter, (like p: or z:).
In most cases you'll want to use a folder whose root path is c:\ or d:\
Each chapter folder has a C# and a VB subfolder containing
complete projects in the respective language.

Notes for SystemBrowser code (Chapter 11)

    In Visual Studio, open the solution file "SystemBrowser.sln".
    Build the solution, then press the F5 key to run the program.
    To run the various test fixtures, right click on a test fixture project
    in the Visual Studio Solution Explorer and select the "Set as Startup Project"
    command from the context menu. Press F5 to run the selected test fixture.

Notes for Pipelined HttpService code (Chapter 12)

    In Visual Studio, open the solution file "Pipelined Http Service.sln".
    Build the solution. To run the code, you must tell Visual Studio
    to run multiple projects together. In the Visual Studio Solution Explorer,
    right click on the solution node (the root node) and select "Set Startup Projects"
    from the context menu. On the dialog box that appears, select the radiobutton 
    "Multiple Startup Projects". In the grid there is an Action column. 
    For the projects HostEmulator and Client, change the action from None to Start. 
    Leave HttpService's action set to None, because HttpService is a DLL and 
    can't be run by itself. The Client project will load HttpService automatically. 
    Use the Move Up button so the projects are listed in the following order:

    - HostEmulator
    - Client
    - HttpService

    Click the OK button to close the dialog box. Press the F5 key to run the code.
    Two separate program windows will appear. In the Client Test Fixture window,
    select the number of pipelined requests to send concurrently, then click the
    "Send" button. The Host Emulator will show the incoming requests being handled.
    After a random amount of time, the Host Emulator returns a response for each
    request.
    
Notes for ASAP Cars code (Chapter 13)

    In Visual Studio, open the solution file "ASAP Cars.sln".
    Build the solution. To run the code, you must tell Visual Studio
    to run multiple projects together. In the Visual Studio Solution Explorer,
    right click on the solution node (the root node) and select "Set Startup Projects"
    from the context menu.
    On the dialog box that appears, select the radiobutton "Multiple Startup Projects".
    In the grid there is an Action column. For the projects Invoicing, Order Entry,
    Order Processor Host Program, Parts Scheduling and Vehicle Assembly, 
    change the action from None to Start.
    Use the Move Up button so the projects are listed in the following order:

    - Order Processor Host Program
    - Parts Scheduling
    - Vehicle Assembly
    - Invoicing
    - Order Entry

Click the OK button to close the dialog box. Press the F5 key to run the code. 
Five separate program windows will appear.
In the Client window (whose caption is "ASAP Cars - Custom Tailor Your Car"),
click some of the checkboxes and then click the Submit Order button.
You'll see a list of three parts show up in the Parts Scheduling window. After about
10 seconds, to simulate the time required to get the necessary parts,
the orders are processed. The parts are removed from the Parts Scheduling window,
the Order Status window increments its counter of processed orders and an order
is sent to the Vehicle Assembly component. This component has a blank interface,
with no controls. The Vehicle Assembly component sends the order to the Invoicing 
component, which updates a counter of processed invoices.
