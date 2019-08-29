# TradeRevUIAutomation
It is UI Selenium and MSTest based UI Automation framework.

Follow the below steps to Run the Automation Suite on Windows OS :

1.  Clone the repository to get the Source code and build the TradeRevUIAutomationSln.sln file

2. This will generate the required binaries. Now copy the path of TradeRevUITest.dll (It would be <Your RepositoryPath>\TradeRevUIAutomation\Product\TradeRevUITest\bin\Debug\TradeRevUITest.dll)
  
3. Make sure you have Chrome browser installed.

4. Make sure you have vstest.console.exe on your System to run the tests . If not, then you might need to install Visual Studio Test Agent to get this exe . You can follow the below link to download and install visual studio test agent 
https://visualstudio.microsoft.com/downloads/?q=agents
If you have VS Studio 2017 installed, then vstest.console.exe should be under the following path
C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\CommonExtensions\Microsoft\TestWindow

5. Now open command prompt with Elevated permissions (Run as Administartor) and browse to the directory where vstest.console.exe is located.

6. Run the following command
vstest.console.exe <YourRepositoryPath>\TradeRevUIAutomation\Product\TradeRevUITest\bin\Debug\TradeRevUITest.dll /logger:trx;LogFileName=<PathToResultsFile>\<ResultFileName>.trx
  
7. Wait for the Tests to finish (all 3 would run in parallel)

8. To view results, open the <PathToResultsFile>\<ResultFileName>.trx file generated in Visual Studio.
  Double click the Test case entry and to view the Console Logs, double lick the results row.

