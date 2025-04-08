import React from 'react';
import '../CSS/About.css'; 
import EmailIcon from '@mui/icons-material/Email';
import FacebookIcon from '@mui/icons-material/Facebook';
import aboutImage from './Kevin.jpg';

const About = () => {
    return (
        <div className="about-container">
            <h2>About Me</h2>
            <div className="about-content">
                <img
                    src={aboutImage}
                    alt="About Us"
                    className="about-image"
                />
                <p>
                   Hi I'm kevin you're handsome, IT Student in Saint Mary's University and a talented developer. I am a backend developer with a passion for creating<br/> 
                   efficient and scalable applications. I have experience in various programming languages and frameworks, and I love solving problems that are not too hard.<br/> 
                   In my free time, I enjoy playing games and dabbling on some projects. I believe in continuous learning and strive to improve my skills every day.                   
                </p>
            </div>
            <div className="contact-section">
                <h3>Contact Me</h3>
                <div className="contact-links">
                    <a href="jadenyuki@486@gmail.com" className="contact-link">
                    <EmailIcon sx={{ color: 'white' }} className="icon" /> Gmail
                    </a>
                    <a href="https://www.facebook.com/kevin.klein.vallejo.ananayo/" className="contact-link">
                    <FacebookIcon sx={{ color: 'white' }} className="icon" /> Facebook
                    </a>
                </div>
            </div>
        </div>
    );
};

export default About;