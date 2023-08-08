# Console Helper
C# Class Library that contains static functions to easily write messages to console with timestamps and colored tags, and handles exceptions.

## Console Manager
Static C# Class, the main module of Console Helper used for mainly for calling it's own WriteLine function allowing the user to pass a ConsoleMessageTag.
```c#
public static void ForceDebugMessages(bool Force)
public static void WriteLine(string _Line, ConsoleMessageTag _Tag)
private static void PostMessage(string _Line, string Tag, ConsoleColor TagColor)
```

## Exception Handler
Static C# Class, uses a single function to take in a generic exception, and a boolean value, as parameters. It then writes the exception information to the Console using the Console Manager WriteLine function. A log is also written to file, if a Log folder does not exist, then one will be created and the exception data will be saved to text file with the current date/time as the name. The user is then prompted on if they would like to continue the execution of the application or exit the application by pressing either Y/N. The boolean parameter passed to the handle function determines if the user should be prompted or if the application should exit automatically after informing the user of the exception and the creation of the log file.
```c#
public static void Handle(Exception Ex, bool PromptUser)
```
