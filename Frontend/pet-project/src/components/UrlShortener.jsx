import { useEffect, useState } from 'react'
import '../styles/UrlShortener.css'
import UrlShortenerForm from './UrlShortenerForm.jsx'
import ShortUrlBlock from './ShortUrlBlock.jsx';
import { ShortUrl } from '../services/urls.js';

function UrlShortener() {

  const [URL, SetURL] = useState(null);

  const onCreateUrl = async (e) => {
    SetURL(await ShortUrl(e));
    return URL;
  }

  if(URL != null)
  {
    return (
        <>
        <UrlShortenerForm onCreateUrl={onCreateUrl}/>
        <ShortUrlBlock readyShortURL={URL}/>
        </>
    )
  }
  else {
    return (
        <>
        <UrlShortenerForm onCreateUrl={onCreateUrl}/>
        </>
    )
  }
}

export default UrlShortener