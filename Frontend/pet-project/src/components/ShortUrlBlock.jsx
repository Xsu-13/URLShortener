import { useState, useEffect } from 'react';
import '../styles/ShortUrlBlock.css'

function ShortUrlBlock({readyShortURL}) {

    const [url, SetUrl]=useState("");
    const [copied, setCopied] = useState(false);

    useEffect(() => {
        SetUrl(readyShortURL.replace("http://localhost:5136/", ""));
    }, [readyShortURL]);

    function CopyUrl(e)
    {
        navigator.clipboard.writeText(readyShortURL);
        setCopied(true);

        // Скрытие сообщения через 2 секунды
        setTimeout(function() {
            setCopied(false);
        }, 2000);
    }

    if(readyShortURL)
    {
        return (
            <>
            <div className="container-block">
                <div className="url-container">
                    <a href={readyShortURL} target='_blank'>
                    <svg fill="#fff" height="20%" width="20%" version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" 
                        viewBox="0 0 54.971 54.971" xml:space="preserve">
                    <g>
                        <path d="M51.173,3.801c-5.068-5.068-13.315-5.066-18.384,0l-9.192,9.192c-0.781,0.781-0.781,2.047,0,2.828
                            c0.781,0.781,2.047,0.781,2.828,0l9.192-9.192c1.691-1.69,3.951-2.622,6.363-2.622c2.413,0,4.673,0.932,6.364,2.623
                            s2.623,3.951,2.623,6.364c0,2.412-0.932,4.672-2.623,6.363L36.325,31.379c-3.51,3.508-9.219,3.508-12.729,0
                            c-0.781-0.781-2.047-0.781-2.828,0s-0.781,2.048,0,2.828c2.534,2.534,5.863,3.801,9.192,3.801s6.658-1.267,9.192-3.801
                            l12.021-12.021c2.447-2.446,3.795-5.711,3.795-9.192C54.968,9.512,53.62,6.248,51.173,3.801z"/>
                        <path d="M27.132,40.57l-7.778,7.778c-1.691,1.691-3.951,2.623-6.364,2.623c-2.412,0-4.673-0.932-6.364-2.623
                            c-3.509-3.509-3.509-9.219,0-12.728L17.94,24.306c1.691-1.69,3.951-2.622,6.364-2.622c2.412,0,4.672,0.932,6.363,2.622
                            c0.781,0.781,2.047,0.781,2.828,0s0.781-2.047,0-2.828c-5.067-5.067-13.314-5.068-18.384,0L3.797,32.793
                            c-2.446,2.446-3.794,5.711-3.794,9.192c0,3.48,1.348,6.745,3.795,9.191c2.446,2.447,5.711,3.795,9.191,3.795
                            c3.481,0,6.746-1.348,9.192-3.795l7.778-7.778c0.781-0.781,0.781-2.047,0-2.828S27.913,39.789,27.132,40.57z"/>
                    </g>
                    </svg>
                    <div className="url"> {url ?? ""}</div>
                    </a>
                    <button className="copy-button" onClick={(e) => CopyUrl(e)}> {copied && <div id="copiedMessage" class="copied-message">Скопировано</div>} Копировать <span className="ctrl">ctrl+c</span> </button>
                </div>
            </div>
            </>
        )
    }
}

export default ShortUrlBlock