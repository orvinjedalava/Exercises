import { Greet } from '../Greet';

// extracts the props from another component ( e.g. Greet component )
export const CustomComponent = (props: React.ComponentProps<typeof Greet>) => {
    return (
        <div>
            {props.name}
            {props.isLoggedIn}
            {props.messageCount}
        </div>
    )
}