# LocalNetworkFileSharer
Local network file sharer - simple local network file sharing service for Windows.

Recommendations (follow them if you don't want to catch bug):
- Use buttons and panels to interact with program.
- Don't use symbols ':','\n' in device name or commit name.
- Don't try to change save-file.
- clearing connections panel in server panel will make program work faster.
- Use button to update commits list in connected user panel.
- Don't use more than one '.' in uplading/downloading file (one '.' is like '.txt').
- When you are saving file write: path + name (with out file type); Example 'D:\Myfiles\save' (file type will be identified automatically)
- Write 'help' in console if you need commands list

Recomendations for server exploitation:
- I recomend to don't use ports like 80,443,22, because they can send your packages incorrect. (you can use ports like 1000+,5,1 and other rarely used ports)
- You can enable auto-saving mode for logger and if something goes wrong, you'll be able to find error in log file.
- You can use command 'ips_tot_conns_list' to see how many connections were created during server was working.
- You can use command 'tot_mem_cln' to delete all unnecessary data.

# Base information:
- You can find .exe file there: "/LNetworkFileShare/bin/Debug/net10.0-windows/LNetworkFileShare.exe"
- Program needs Dotnet 10 to work, so you can download it here: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-10.0.103-windows-x64-installer ;
