# CopyWithLineNumbers
Copy With Line Numbers Visual Studio Plugin

* This is a plugin for Visual Studio which copies with line numbers to the clipboard.
* The solution and project file are for Visual Studio 2017.
* It works on Visual Studio 2015 and 2017.
* The copying text can be customizable by template. See the manual page for detail.

## Example

This is an example text which is sent to clipboard.

### Example1

	   11:         public static void Main(string[] args)
	   12:         {
	   13:         }

### Example2

	   c:\Test\ConsoleApp\ConsoleApp\Program.cs(11) - (13):
	   11:         static void Main(string[] args)
	   12:         {
	   13:         }

### Example3

	   ConsoleApp\Program.cs:
	   11:         static void Main(string[] args)
	   12:         {
	   13:         }

### Example4

	   Program.cs(11):
	   11:         static void Main(string[] args)
	   12:         {
	   13:         }


## Get Binary

download from the following links

* [GitHub Release](https://github.com/m-tmatma/CopyWithLineNumbers/releases)
* [Microsoft Market Place](https://marketplace.visualstudio.com/items?itemName=tmatma.CopyWithLineNumbers-18783)

## Get Source Code

	> git clone https://github.com/m-tmatma/CopyWithLineNumbers.git

## Build

### Build by IDE

1. Open CopyWithLineNumbers.sln with Visual Studio 2017
1. Compile Solution

### Build by Jenkins

1. "C:\Program Files (x86)\NuGet\nuget.exe" restore CopyWithLineNumbers.sln
1. "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.com" CopyWithLineNumbers.sln /rebuild "Release|Any CPU"

## Manual

### English

https://m-tmatma.github.io/VC/CopyWithLineNumbersManualEN.html

### Japanese

https://m-tmatma.github.io/VC/CopyWithLineNumbersManualJP.html



