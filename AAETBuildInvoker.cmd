rem =======================================================================
rem add the framework directory to the path variable - we'll need this for msbuild
rem refer this Link for reference http://thomasardal.com/msbuild-tutorial/ 
set path=%path%;C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319

msbuild AAET.build.proj /T:"BuildProcesses" /P:"Configuration=Release"