import { useNavigate, NavLink } from 'react-router-dom';

import * as authService from '../services/userService';

const Register = () => {

    const navigate = useNavigate()

    const submit = (e) => {
        e.preventDefault();

        let formData = new FormData(e.currentTarget)

        let username = formData.get('nickname');
        let email = formData.get('email');
        let password = formData.get('password');

        let response = authService.register( username, email, password);
        console.log(response);
        if(response){
            navigate('/login');
        }else{
            e.currentTarget.reset();
        }        
    };
    return (
        <>
            <section id="register-page" className="content auth">
                <form id="register" onSubmit={submit}>
                    <div className="container">
                        <h1>Register</h1>

                        <label htmlFor="nickname">Username:</label>
                        <input type="nickname" id="nickname" name="nickname" placeholder="maria" />

                        <label htmlFor="email">Email:</label>
                        <input type="email" id="email" name="email" placeholder="maria@email.com" />

                        <label htmlFor="pass">Password:</label>
                        <input type="password" name="password" id="register-password" />

                        <label htmlFor="con-pass">Confirm Password:</label>
                        <input type="password" name="confirm-password" id="confirm-password" />

                        <input className="btn submit" type="submit" value="Register" />


                    </div>
                </form>
            </section>
            <p className="field">
                <span>If you already have profile click <NavLink className="active-navigation-link" to="/login">here.</NavLink></span>
            </p>
        </>

    );
}

export default Register;