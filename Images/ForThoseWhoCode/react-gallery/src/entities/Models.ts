export interface Image {
    title: string;
    url: string;
}

export interface ModalProps {
    image: Image;
    handleRotationRight: () => void;
    handleRotationLeft: () => void;
    setClickedImage: React.Dispatch<React.SetStateAction<Image | null>>;
}