
namespace AutoMapperSample
{
  class Program
  {
    static void Main(string[] args)
    {
      var sample = new AutoMapperSample();

      // AutoMapperのサンプル１ : メンバーがまったく同じオブジェクトのマッピング
      sample.ExecuteSample1();

      // AutoMapperのサンプル２ : コピー元とコピー先でメンバが異なる場合
      sample.ExecuteSample2();

      // AutoMapperのサンプル３ : コレクションからコレクションへのマッピング
      sample.ExecuteSample3();

    }
  }
}
