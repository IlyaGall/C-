
var a = new Alpha();
a.A = 10;
var b = a;
a.A = 100;
Console.WriteLine(b.A);




var c = new Beta();
c.A = 10;

var d = c;

c.A = 100;
Console.WriteLine(d.A);


var p1 = new Dot3D(1, 2, 2);
p1.Point = new Alpha();
p1.Point.A = 10;

var p2 = p1;
p1.Point.A = 100;
Console.WriteLine(p2.Point.A);



var alpha1 = new Alpha() { A = 10 };

var alpha2 = new Alpha() { A = 10 };

Console.WriteLine("---------");
Console.WriteLine(alpha1.Equals(alpha2));



var beta1 = new Beta() { A = 10 };

var beta2 = new Beta() { A = 10 };


Console.WriteLine(beta1.Equals(beta2));


Console.WriteLine("---------");


var ws = new WithString();
var g = Guid.NewGuid();
var g1 = new Guid();


var listOfAlpha = new List<Alpha> { new Alpha { A = 10 } };

listOfAlpha[0].A = 1000;



var listOfBeta = new List<Beta> { new Beta { A = 10 } };

listOfBeta[0] = new Beta { A = 111 };

var ws2 = new WithString();
ws2.SuperString = "124";
ws2.SuperString = "1424224";

Console.WriteLine("-----------");
DocumentType myDoc = DocumentType.DriveLicence;
//myDoc = (DocumentType)123;

RoleFeature rfHr = RoleFeature.DownloadFile | RoleFeature.RemoveFile;

Console.WriteLine((rfHr));
Console.WriteLine(rfHr.HasFlag(RoleFeature.DownloadFile));

Console.WriteLine("----Op1-----");
var res1 = Pos1() || Pos2();
Console.WriteLine(res1);


Console.WriteLine("----Op2-----");
var res2 = Pos1() | Pos2();
Console.WriteLine(res2);

bool Pos1()
{
    Console.WriteLine("POS1");
    return true;
}

bool Pos2()
{
    Console.WriteLine("POS2");
    return true;
}
public enum DocumentType
{
    Passport = 5,
    ForeignPassport = 10,
    DriveLicence = 1003,
    PassportMoryka,
}

public enum RoleFeature
{
    DownloadFile = 1, //  0001     1-0001
    SaveSettings = 2, //  0010      2- 0010
    CreateMessage = 4, // 0100     3-0011
    RemoveFile = 8,//     1000
}


[Flags]
public enum RoleFeature1
{
    DownloadFile, //  0001     1-0001
    SaveSettings, //  0010      2- 0010
    CreateMessage, // 0100     3-0011
    RemoveFile,//     1000
}

// 0001 | 
// 1000
// 1001   - число 9


// 1110



public bool HasFlag(RoleFeature val, RoleFeature flag)
{
    return val & flag == flag;
}





struct WithString
{
    public const string SuperCOnstString = "";
    public string SuperString { get; set; }
}




struct Beta
{
    public int A;

    public void DoSomething()
    {
        Console.WriteLine("Do something");
    }
}





public class Alpha
{
    public int A;
}

public interface IDuck
{
    public void Quack();
}

struct Dot2D : IDuck
{

    public int X { get; set; }

    public int Y { get; set; }

    public void Quack()
    {
        throw new NotImplementedException();
    }
}

struct Dot3D
{
    public Dot3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }

    public Alpha Point { get; set; }
}

