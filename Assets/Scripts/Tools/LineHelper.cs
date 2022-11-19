using System.Exception;

public class LineHelper{
    private string[] lines;
    private int counter;
    private static int limit;

    public LineHelper(string lines){
        this.lines = lines.Split('\n');
        counter = 0;
        limit = lines.Length;
    }

    public string GetLine(){
        if(counter >= limit) throw new OutOfLineLimitException();
        return lines[++counter];
    }

    public string[] GetLines(int count){
        string[] result = new string[count];

        for(int i = 0; i < count; i++){
            result[i] = GetLine();
        }

        return result;
    }
}

public class OutOfLineLimitException : Exception{
    
    public OutOfLineLimitException() : base("Out Of Line Limit Exception !") { }

    public OutOfLineLimitException(Exception inner) : base("Out Of Line Limit Exception !", inner) { }
}