// import React from 'react';
// import logo from './logo.svg';
// import './App.css';
import { useState } from 'react';
import data from './data/images.json';
import { Image } from './entities/Models';
import Modal from './components/Modal';

function App() {

  const [clickedImage, setClickedImage] = useState<Image | null>(null);
  const [currentIndex, setCurrentIndex] = useState<number | null>(null);

  const handleClick = (event: React.MouseEvent<HTMLImageElement>, image: Image, index: number) => {
    //console.log(event.currentTarget.src);
    setCurrentIndex(index);
    setClickedImage(image);
  }

  const handleRotationRight = () => {
    const totalLength: number = data.data.length;
    if (currentIndex !== null) {
      const nextIndex = (currentIndex + 1) % totalLength;
      setCurrentIndex(nextIndex);
      setClickedImage(data.data[nextIndex]);
    }
  }

  const handleRotationLeft = () => {
    const totalLength: number = data.data.length;
    if (currentIndex !== null) {
      const nextIndex = (currentIndex - 1 + totalLength) % totalLength;
      setCurrentIndex(nextIndex);
      setClickedImage(data.data[nextIndex]);
    }
  }

  return (
    <div className="wrapper">
      {data.data.map((image: Image, index: number) => (
        <div key={index} className="wrapper-images">
          <img src={image.url} alt={image.title} onClick={e => handleClick(e, image, index)}/>
          <h2>{image.title}</h2>
        </div>
      ))}
      {clickedImage && 
        <Modal 
          image={clickedImage}
          handleRotationLeft={handleRotationLeft}
          handleRotationRight={handleRotationRight}
          setClickedImage={setClickedImage}/> 
      }
    </div>
  );
}

export default App;
