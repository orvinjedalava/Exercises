import { ModalProps } from "../entities/Models";

function Modal({image, handleRotationRight, handleRotationLeft, setClickedImage}: ModalProps ) {

    const handleClick = (e: React.MouseEvent<HTMLElement, MouseEvent>) => {
        if ((e.target as HTMLElement).classList.contains('dismiss')) {
            setClickedImage(null);
        }
    }

    return (
        <div className="overlay dismiss" onClick={e => handleClick(e)}>
            <img src={image.url} alt={image.title}/>
            <span className="dismiss" onClick={e => handleClick(e)}>X</span>
            <div onClick={handleRotationLeft} className="overlay-arrows_left">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    className="h-5 w-5"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                >
                <path
                    fillRule="evenodd"
                    d="M9.707 16.707a1 1 0 01-1.414 0l-6-6a1 1 0 010-1.414l6-6a1 1 0 011.414 1.414L5.414 9H17a1 1 0 110 2H5.414l4.293 4.293a1 1 0 010 1.414z"
                    clipRule="evenodd"
                />
                </svg>
            
            </div>
            <div onClick={handleRotationRight} className="overlay-arrows_right">
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    className="h-5 w-5"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                >
                <path
                    fillRule="evenodd"
                    d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z"
                    clipRule="evenodd"
                />
                </svg>
          
            </div>
        </div>
    );
}

export default Modal;