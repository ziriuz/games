using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;

public class NetworkService {

    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=Krakow,pl&mode=xml&APPID=364134df684517b1a01335130c8e7c2b";
    private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=Krakow,pl&APPID=364134df684517b1a01335130c8e7c2b";
    private IEnumerator CallAPI(string url, WWWForm form, Action<string> callback) {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.Send(); //Пауза в процессе скачивания.

            if (request.isNetworkError)
            {
                Debug.LogError("network problem: " + request.error);
            }
            else if (request.responseCode != (long) System.Net.HttpStatusCode.OK)
            {
                Debug.LogError("response error: " + request.responseCode);
            }
            else
            {
                callback(request.downloadHandler.text);
            }
        }
    }

	public IEnumerator GetWeatherXML(Action<string> callback) {
		return CallAPI(xmlApi, null, callback);
	}
    public IEnumerator GetWeatherJSON(Action<string> callback)
    {
        return CallAPI(jsonApi, null, callback);
    }
}
