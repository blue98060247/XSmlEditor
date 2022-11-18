using System.Collections;
using System.Collections.Generic;
using System;

public static class Global
{
    private static Log logger;
    public static XSMLReader xsmlReader;
    public static SJSon SJSonReader;

    public static void Init()
    {
        logger = new Log();
    }

    public static void Log(string log){
        logger.WriteLog(log);
    }
}
