type GreetProps = {
    name: string;
    messageCount?: number;
    isLoggedIn: boolean;
}

export const Greet = (props: GreetProps) => {
    // since messageCount is optional, we need to provide a default value
    const { messageCount = 0 } = props;
    return (
        <div>
            <h2>
                {
                    props.isLoggedIn ? `Welcome ${props.name}! You have ${messageCount} unread messages.`
                    : 'Welcome Guest.'
                }
            </h2>
        </div> 
    ) ;
}