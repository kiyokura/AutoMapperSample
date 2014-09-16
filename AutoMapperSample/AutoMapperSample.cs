using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperSample
{
  class AutoMapperSample
  {
    /// <summary>
    /// AutoMapperのサンプル１ : メンバーがまったく同じオブジェクトのマッピング
    /// </summary>
    public void ExecuteSample1()
    {
      // DBからとってきた（という体裁の）Memberクラスを、
      // 全く同じメンバを持つ、User にマッピングする例

      // Mapperを作成
      Mapper.CreateMap<Member, User>();

      // DBか何かからMember型でデータをとってきたと思ってください
      Member member = new Member()
      {
        ID = 15,
        Name = "Narami Kiyokura",
        Age = 20
      };

      //  Member型のmemberをUser型にマップ
      User user = Mapper.Map<User>(member);


      Console.WriteLine("ID:{0}", user.ID);
      Console.WriteLine("Name:{0}", user.Name);
      Console.WriteLine("Age:{0}", user.Age);

      Console.ReadKey();
    }

    /// <summary>
    /// AutoMapperのサンプル２ : コピー元とコピー先でメンバが異なる場合
    /// </summary>
    public void ExecuteSample2()
    {
      // DBからとってきた（という体裁の）Peopleクラスを、
      // 一部異なる名前のフィールドを持つStudent にマッピングする例

      // Mapperを作成
      // .ForMemberメソッドで移行先の何をセットするか指定する
      // Student.ID に PeopleID をマップ
      // Student.Name に People.FirstName とPeople.LastName を組み立てた値をマップ
      // Student.Class にはClassはマップしない
      // 
      // お互いに存在しないものは何もしなくても無視する（People.PrefCodeやStudent.Club）
      Mapper.CreateMap<People, Student>()
        .ForMember(d => d.ID, o => o.MapFrom(s => s.PeopleID))
        .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName + " " + s.LastName))
        .ForMember(d => d.Class, o => o.Ignore());

      // DBか何かからPeople型でデータをとってきたと思ってください
      People people = new People()
      {
        PeopleID = 15,
        FirstName = "Narami",
        LastName = "Kiyokura",
        Class = "これはマップしない",
        PrefCode = 33
      };

      //  People型のpeopleをStudent型にマップ
      Student student = Mapper.Map<Student>(people);


      Console.WriteLine("ID:{0}", student.ID);
      Console.WriteLine("Name:{0}", student.Name);
      Console.WriteLine("Class:{0}", student.Class);
      Console.WriteLine("Club:{0}", student.Club);

      Console.ReadKey();
    }


    /// <summary>
    /// AutoMapperのサンプル３ : コレクションからコレクションへのマッピング
    /// </summary>
    public void ExecuteSample3()
    {
      // DBからとってきた（という体裁の）Memberクラスのコレクションを、
      // 全く同じメンバを持つ、Userのコレクション にマッピングする例

      // Mapperを作成
      // ここで指定するのはMember型とUser型
      Mapper.CreateMap<Member, User>();

      // DBか何かからMember型のコレクションでデータをとってきたと思ってください
      List<Member> members = new List<Member>(){
    new Member()
    {
      ID = 15,
      Name = "Narami Kiyokura",
      Age = 20
    },
                        new Member()
    {
      ID = 17,
      Name = "Taro Yamada",
      Age = 25
    }
  };

      //  Member型のmemberをUser型にマップ
      List<User> users = Mapper.Map<List<User>>(members);

      foreach (var user in users)
      {
        Console.WriteLine("ID:{0}", user.ID);
        Console.WriteLine("Name:{0}", user.Name);
        Console.WriteLine("Age:{0}", user.Age);
      }


      Console.ReadKey();
    }
  }

  #region サンプル1用のクラス
  public class User
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }

  public class Member
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
  }


  public class Student
  {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public string Club { get; set; }
  }


  public class People
  {
    public int PeopleID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Class { get; set; }
    public int PrefCode { get; set; }
  }
  #endregion



}
