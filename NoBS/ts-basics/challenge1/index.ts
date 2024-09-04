import houses from './houses.json';

interface House {
  name: string;
  planets: string | string[];
}

interface HouseWithID extends House {
  id: number;
}

function findHouses(houses: string): HouseWithID[];

function findHouses(
  houses: string,
  filter: (house: House) => boolean
): HouseWithID[];

function findHouses(houses: House[]): HouseWithID[];

function findHouses(
  houses: House[],
  filter: (house: House) => boolean
): HouseWithID[];

function findHouses (
  input: string | House[],
  filter? : (house: House) => boolean
): HouseWithID[] {
  const houses: House[] = 
    typeof input === 'string' ? 
      JSON.parse(input as string)
      : input;
  return (
    filter ? 
      houses.filter(filter)
      : houses)
      //.map((house, index) => ({ id: index, ...house })); We want to retain the original index so we use the indexOf method instead of this
      .map(house => ({ id: houses.indexOf(house), ...house }));
}

console.log(
  findHouses(
    JSON.stringify(houses), 
    ({ name }) => name === "Atreides")
);

console.log(
  findHouses(
    houses, 
    ({ name }) => name === "Harkonnen")
);