import { useEffect, useState } from 'react'
import '../styles/UrlShortener.css'

function UrlShortenerForm({onCreateUrl}) {

  const [URL, SetURL] = useState(null);

  const onSubmit = (e) => {
    e.preventDefault();
    onCreateUrl(URL);
  }

  return (
    <>
    <div className="container">
      <form onSubmit={(e) => onSubmit(e)}>
        <div className="logo">
            <span className="logo-text">URL</span>
            <span className="logo-title">.omg</span>
        </div>
        <p className="description">
            Помогите клиентам быстро найти вашу страницу в интернете.<br/> Благодаря короткой ссылке
            клиентам не придётся видеть длинные url-адреса, занимающие много места.
        </p>
        <div className="shorten-form">
            <input type="text" onChange={(e) => {SetURL(e.target.value)}} placeholder="Введите ссылку, которую нужно сократить"/>
            <button type="submit">Сократить</button>
        </div>
      </form>
    </div>
    </>
  )
}

export default UrlShortenerForm
