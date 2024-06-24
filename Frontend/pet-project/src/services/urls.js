import axios from "axios";

export const ShortUrl = async (longUrl) => {
    var url = await fetchShortUrl(longUrl) ?? "Что-то пошло не так."
    return url; 
}


export const fetchShortUrl = async (longUrl) => {
    try{
        var response = await axios.post("http://localhost:5136/", {LongURL: longUrl})
    console.log(response);

    return response.data.shortUrl;

    }
    catch(e)
    {
        console.log(e);
    }
}