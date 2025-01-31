using Newtonsoft.Json.Linq;

namespace MapInfo;
public interface IGisInfo {
  string GetRequestUri();
  string GetCoordinatesByJson(JObject json);
}