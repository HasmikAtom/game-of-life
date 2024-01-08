import React, {useState} from 'react';

interface CellProps {
    id: string
}

export const Cell: React.FC<CellProps> = ({id}: CellProps) => {
    const [isClicked, setIsClicked] = useState(false);
    const [activeCells, setActiveCells] = useState<string[]>(["example"])
    const handleClick = () => {
        console.log("Cell ID", id)
        setIsClicked(!isClicked);

        setActiveCells( // Replace the state
            [ // with a new array
                ...activeCells, // that contains all the old items
                id // and one new item at the end
            ]
        );

        console.log("isClicked", isClicked)
        console.log(activeCells)
    };


    return (
        <div id={id} className={`cell ${isClicked ? 'clicked-cell' : ''}`} onClick={handleClick}>
        </div>
    );
}
