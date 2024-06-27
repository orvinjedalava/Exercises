import React, { Component } from 'react';
import axios from 'axios';

class PostForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            userId: '',
            title: '',
            body: ''
        };
    }

    handleSubmit = (event) => {
        event.preventDefault();
        console.log(this.state);

        axios.post('https://jsonplaceholder.typicode.com/posts', this.state)
            .then(response => {console.log(response)})
            .catch(error => {console.log(error)});
    }

    handleChange = (event) => {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    render() {
        const { userId, title, body } = this.state;
        return (
            <div>
                <form onSubmit={this.handleSubmit}>
                    <div>
                        <label>UserId</label>
                        <input 
                            type="text" 
                            name="userId" 
                            value={userId} 
                            onChange={this.handleChange}/>
                    </div>
                    <div>
                        <label>Title</label>
                        <input 
                            type="text" 
                            name="title" 
                            value={title}
                            onChange={this.handleChange}/>
                    </div>
                    <div>
                        <label>Body</label>
                        <input 
                            type="text" 
                            name="body" 
                            value={body}
                            onChange={this.handleChange}/>
                    </div>
                    <button type="submit">Submit</button>
                </form>
            </div>
        );
    }
}

export default PostForm;