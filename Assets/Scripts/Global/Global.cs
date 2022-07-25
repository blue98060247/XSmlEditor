using System.Collections;
using System.Collections.Generic;
using System;

public static class Global
{
    public static Log logger;
    public static XSMLReader xsmlReader;

    public static void Init()
    {
        logger = new Log();
    }
}
