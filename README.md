# Console Helper
C# Class Library that contains static functions to easily write messages to console with timestamps and colored tags, and handles exceptions.

## Console Manager
Static C# Class, the main module of Console Helper used for mainly for calling it's own WriteLine function allowing the user to pass a ConsoleMessageTag.
```c#
public static void ForceDebugMessages(bool Force)
public static void WriteLine(string _Line, ConsoleMessageTag _Tag)
private static void PostMessage(string _Line, string Tag, ConsoleColor TagColor)
```
